using Task4_ProcessingTextRecords.Logic;

namespace Task4_ProcessingTextRecords
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Task1Button_Click(object sender, EventArgs e)
        {
            var text = Task1TextInput.Text;
            var result = StringProcessor.Task1Process(text);
            PrintListSearchResult(listBox1, result);

        }

        private void Task2Button_Click(object sender, EventArgs e)
        {
            vowelCountLabel.Text = "";
            consonantsCountLabel.Text = "";

            var text = Task2TextInput.Text;
            var shouldCheckVowels = VowelsRadioButton.Checked;
            var charsCount = StringProcessor.Task2Process(text, shouldCheckVowels);

            var labelToUpdate = shouldCheckVowels ? vowelCountLabel : consonantsCountLabel;
            labelToUpdate.Text = "Кількість літер: " + charsCount;
        }

        private void Task3Button_Click(object sender, EventArgs e)
        {
            var text = Task3TextInput.Text;
            var result = StringProcessor.Task3Process(text);

            PrintListSearchResult(listBox2, result);
        }


        private void PrintListSearchResult(ListBox lb, IEnumerable<string> results)
        {
            lb.Items.Clear();

            lb.Items.Add("Всього слів: " + results.Count());
            lb.Items.Add("");

            foreach (var word in results)
            {
                lb.Items.Add(word);
            }
        }

        private void Task4Button_Click(object sender, EventArgs e)
        {
            var text = Task4Input.Text;

            var firstMatch = StringProcessor.Task3ProcessSingleMatch(text);
            Task4SingleMatchResultLabel.Text = firstMatch;

            var allMatches = StringProcessor.Task3ProcessMultipleMatches(text);
            Task4MultipleMatchResultsLabel.Text = String.Join(", ", allMatches);

            
        }
    }
}
