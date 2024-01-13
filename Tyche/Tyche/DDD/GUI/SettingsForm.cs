using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tyche.DDD.Application;

namespace Tyche.Domain.GUI
{
    public partial class SettingsForm : Form, IObservable<Form>
    {
        private List<IObserver<Form>> observers;
        private List<Subscription<Form>> subscriptions;
        public SettingsForm()
        {
            InitializeComponent();
            FillDataGrid();
            observers = new List<IObserver<Form>>();
            subscriptions = new List<Subscription<Form>>();
            this.FormClosed += (o, e) => Notify(this);
            this.FormClosed += (o, e) => CloseSubscriptions();
        }

        private void FillDataGrid()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Property", typeof(string)).ReadOnly = true;
            dataTable.Columns.Add("Value", typeof(string));
            foreach (SettingsProperty prop in Properties.Settings.Default.Properties)
                dataTable.Rows.Add(prop.Name, Properties.Settings.Default[prop.Name].ToString());
            dataGridViewSettings.DataSource = dataTable;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CloseSubscriptions()
        {
            foreach (var sub in subscriptions)
                sub.CloseSubscription();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var name = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                var x = 0.0;
                try
                {
                    x = Double.Parse(cell.Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Wrong input.");
                }
                try
                {
                    if (name == "Seed")
                        Properties.Settings.Default[name] = (ulong)x;
                    else
                        Properties.Settings.Default[name] = x;
                    SaveAndUpdateSettings();
                }
                catch
                {
                    MessageBox.Show("Invalid operation.");
                }

            }
        }

        public IDisposable Subscribe(IObserver<Form> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            var sub = new Subscription<Form>(this, observer, observers);
            subscriptions.Add(sub);
            return sub;
        }

        private void Notify(Form form)
        {
            foreach (var observer in observers)
                observer.OnNext(form);
        }

        private void SaveAndUpdateSettings()
        {
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Properties.Settings.Default.Upgrade();
        }
    }
}
