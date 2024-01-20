using static System.Net.Mime.MediaTypeNames;
using Ninject.Modules;
using Ninject;
using System;
using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.CompilerServices;
using Tyche.DDD.Application;

namespace Tyche.DDD.GUI;

public partial class MainForm : Form, IObservable<Form>
{
    private RandomInformation currentRandom;
    private DistributionInformation currentDistribution;
    private List<DistributionInformation> distributions;
    private List<RandomInformation> randoms;
    private Engine engine;
    private List<IObserver<Form>> observers;
    private List<Subscription<Form>> subscriptions;
    private int min;
    private int max;

    public MainForm(Engine engine)
    {
        this.engine = engine;
        observers = new List<IObserver<Form>>();
        subscriptions = new List<Subscription<Form>>();
        InitializeComponent();
        toolTip_InputHelp.SetToolTip(button_InputHelp,
    "Constraints are applied to the input parameter, not the result." +
    " \n Example: f(x) = 5x * 2. The result will not be in the specified range, " +
    "but the x parameter will be.");
        FillRandomInformation();
        FillDistributionInformation();
        SelectDefaultValues();
    }

    private void comboBox_Random_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentRandom = (RandomInformation)comboBox_Random.SelectedItem;
        textBox_Description.Text = currentRandom.Description;
    }

    private void comboBox_Distribution_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentDistribution = (DistributionInformation)comboBox_Distribution.SelectedItem;
        textBox_Description.Text = currentDistribution.Description;
    }

    private void FillRandomInformation()
    {
        randoms = new List<RandomInformation>(engine.GetRandomInfoList());
        randoms.ForEach(x => comboBox_Random.Items.Add(x));
    }

    private void FillDistributionInformation()
    {
        distributions = new List<DistributionInformation>(engine.GetDistributionInfoList());
        distributions.ForEach(x => comboBox_Distribution.Items.Add(x));
    }

    private void SelectDefaultValues()
    {
        try
        {
            currentDistribution = distributions.First();
            currentRandom = randoms.First();
            comboBox_Distribution.SelectedItem = currentDistribution;
            comboBox_Random.SelectedItem = currentRandom;
            min = 0;
            max = 100;
            numericUpDown_Min.Value = min;
            numericUpDown_Max.Value = max;
        }
        catch
        {
            throw new InvalidOperationException("Одна или несколько коллекций не содержат элементов");
        }
    }

    private void button_Generate_Click(object sender, EventArgs e)
    {
        textBox_Answer.Text = engine.GenerateDistributionValue(min, max, currentDistribution.Type, currentRandom.Type).ToString();
    }

    private void numericUpDown_Min_ValueChanged(object sender, EventArgs e)
    {
        min = (int)numericUpDown_Min.Value;
    }

    private void numericUpDown_Max_ValueChanged(object sender, EventArgs e)
    {
        max = (int)numericUpDown_Max.Value;
    }

    private void button_GenerateRandomValue_Click(object sender, EventArgs e)
    {
        textBox_Answer.Text = engine.GenerateRandomValue(min, max, currentRandom.Type).ToString();
    }

    private void button_Settings_Click(object sender, EventArgs e)
    {
        Notify(this);
    }

    public IDisposable Subscribe(IObserver<Form> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
        var subscription = new Subscription<Form>(this, observer, observers);
        subscriptions.Add(subscription);
        return subscription;
    }

    private void Notify(Form form)
    {
        foreach (var observer in observers)
            observer.OnNext(form);
    }

    private void textBox_Answer_TextChanged(object sender, EventArgs e)
    {

    }
}