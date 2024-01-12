using Tyche.Domain.Application;
using static System.Net.Mime.MediaTypeNames;
using Ninject.Modules;
using Tyche.Domain.Models;
using Ninject;

namespace Tyche;

public partial class MainForm : Form
{
    private static RandomInformation currentRandom;
    private static DistributionInformation currentDistribution;
    private static List<DistributionInformation> distributions;
    private static List<RandomInformation> randoms;
    private static int min;
    private static int max;
    private Engine engine;
    public MainForm(Engine engine)
    {
        this.engine = engine;
        InitializeComponent();
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
}

public class EngineModule : NinjectModule
{
    public override void Load()
    {
        Bind<MainForm>().ToSelf().InSingletonScope();
    }
}