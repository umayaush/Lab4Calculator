using System.Data;

namespace Lab4Calculator
{
    public partial class MainPage : ContentPage
    {
        // store current input in a string
        private string currentInput = string.Empty;

        public string CurrentInput
        {
            get => currentInput;
            set
            {
                currentInput = value;
                OnPropertyChanged(nameof(CurrentInput));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        // event handler for digit buttons
        private void OnDigitButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            CurrentInput = currentInput;
        }

        // event handler for operation buttons
        private void OnOperationButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            CurrentInput = currentInput;
        }

        // event handler for the equal button
        private void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // evaluate the expression and update the display
                currentInput = EvaluateExpression(currentInput).ToString();
                CurrentInput = currentInput;
            }
            catch (Exception ex)
            {
                // display "Error" if there's an error while evaluating
                CurrentInput = "Error";
            }
        }

        // event handler for the clear button
        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            // clear the current input and update the display
            currentInput = string.Empty;
            CurrentInput = string.Empty;
        }

        // event handler for the sign change button
        private void OnSignChangeButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && !currentInput.Contains("+") && !currentInput.Contains("-"))
            {
                // add a "-" negative sign to the current input
                currentInput = "-" + currentInput;
                CurrentInput = currentInput;
            }
            else if (currentInput.StartsWith("-"))
            {
                // removie the "-" negative sign if it is already in the current input
                currentInput = currentInput.Substring(1);
                CurrentInput = currentInput;
            }
        }

        // event handler for the decimal button
        private void OnDecimalButtonClicked(object sender, EventArgs e)
        {
            if (!currentInput.Contains("."))
            {
                // add a decimal point to the current input
                currentInput += ".";
                CurrentInput = currentInput;
            }
        }

        // event handler for the percentage button
        private void OnPercentageButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && double.TryParse(currentInput, out double currentValue))
            {
                // convert the current input into a percentage
                currentValue /= 100;
                currentInput = currentValue.ToString();
                CurrentInput = currentInput;
            }
        }

        // evaluate the expression using the DataTable.Compute method
        private double EvaluateExpression(string expression)
        {
            DataTable table = new DataTable();
            return Convert.ToDouble(table.Compute(expression, string.Empty));
        }
    }

}
