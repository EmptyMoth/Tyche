using Tyche.Domain.UI;
using Tyche.Domain.Application;
using static Tyche.Domain.Application.Engine;
using static System.Net.Mime.MediaTypeNames;

namespace Tyche;
public partial class Form1 : Form
{
    private static RandomInformation currentRandom;
    private static DistributionInformation currentDistribution;
    private static List<DistributionInformation> distributions;
    private static List<RandomInformation> randoms;
    private static int min;
    private static int max;
    public Form1()
    {
        InitializeComponent();
        FillRandomInformation();
        FillDistributionInformation();
        SelectDefaultValues();
    }

    private void comboBox_Random_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentRandom = (RandomInformation)comboBox_Random.SelectedItem;
        Engine.SelectRandom(currentRandom.Type);
        textBox_Description.Text = currentRandom.Description;
    }

    private void comboBox_Distribution_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentDistribution = (DistributionInformation)comboBox_Distribution.SelectedItem;
        Engine.SelectDistribution(currentDistribution.Type);
        textBox_Description.Text = currentDistribution.Description;
    }

    private void FillRandomInformation()
    {
        randoms = new List<RandomInformation>() {
            new RandomInformation(RandomType.LCGRandom.ToString(),
            "LCGRandom description",
            RandomType.LCGRandom),
            new RandomInformation(RandomType.MersenneTwisterRandom.ToString(),
            "MersenneTwisterRandom description",
            RandomType.MersenneTwisterRandom),
            //new RandomInformation(RandomType.PCGFastRandom.ToString(),
            //"PCGFastRandom description",
            //RandomType.PCGFastRandom),
            new RandomInformation(RandomType.PCGRandom.ToString(),
            "PCGRandom description",
            RandomType.PCGRandom),
            new RandomInformation(RandomType.XorShiftRandom.ToString(),
            "XorShiftRandom description",
            RandomType.XorShiftRandom)
        };
        randoms.ForEach(x => comboBox_Random.Items.Add(x));
    }

    private void FillDistributionInformation()
    {
        distributions = new List<DistributionInformation>() {
            new DistributionInformation(DistributionType.ExponentialDistribution.ToString(),
            "ExponentialDistribution description",
            DistributionType.ExponentialDistribution),
            new DistributionInformation(DistributionType.NormalDistribution.ToString(),
            "NormalDistribution description",
            DistributionType.NormalDistribution),
            new DistributionInformation(DistributionType.UniformDistribution.ToString(),
            "UniformDistribution description",
            DistributionType.UniformDistribution)
        };
        distributions.ForEach(x => comboBox_Distribution.Items.Add(x));
    }

    private void SelectDefaultValues()
    {
        try
        {
            currentDistribution = distributions.Where(x => x.Type == Engine.SelectedDistribution).FirstOrDefault();
            currentRandom = randoms.Where(x => x.Type == Engine.SelectedRandom).First();
            comboBox_Distribution.SelectedItem = currentDistribution;
            comboBox_Random.SelectedItem = currentRandom;
            min = 0;
            max = 100;
            numericUpDown_Min.Value = min;
            numericUpDown_Max.Value = max;
        }
        catch
        {
            throw new InvalidOperationException("Одна или несколько коллекций не содержат объектов," +
                " соответсвующих текущим элементам Engine. Проверьте коллекции на содержание объектов" +
                "со всеми значениями из enums Engine.");
        }
    }

    private void button_Generate_Click(object sender, EventArgs e)
    {
        textBox_Answer.Text = Engine.GenerateDistributionValue(min, max).ToString();
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
        textBox_Answer.Text = Engine.GenerateRandomValue(min, max).ToString();
    }
}