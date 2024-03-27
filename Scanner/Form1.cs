using Parcel2Go.TechTest.Interfaces;

namespace Scanner
{
    public partial class Form1 : Form
    {
        private readonly ICheckoutService _checkoutService;

        public Form1(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;

            InitializeComponent();

            NewTransaction();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void NewTransaction()
        {
            textBox1.Text = string.Empty;
            _checkoutService.NewTransaction();
            checkoutServiceBindingSource = new BindingSource();
            checkoutServiceBindingSource.DataSource = _checkoutService.Transaction.TransactionItems;
            checkoutServiceBindingSource.ResetBindings(true);

            dataGridView1.DataSource = checkoutServiceBindingSource;
            dataGridView1.Columns[0].Width = dataGridView1.Width / 2;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 2;
            this.Text = string.Format("Transaction #{0} - {1}", _checkoutService.Transaction.Reference.ToString(), _checkoutService.Transaction.Start.ToString("yyyy-MM-dd HH:mm"));
            DisplayTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _checkoutService.Scan(Parcel2Go.TestTest.Entities.Enums.InventoryType.ServiceA);
            checkoutServiceBindingSource.ResetBindings(false);
            DisplayTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _checkoutService.Scan(Parcel2Go.TestTest.Entities.Enums.InventoryType.ServiceB);
            checkoutServiceBindingSource.ResetBindings(false);
            DisplayTotal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _checkoutService.Scan(Parcel2Go.TestTest.Entities.Enums.InventoryType.ServiceC);
            checkoutServiceBindingSource.ResetBindings(false);
            DisplayTotal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _checkoutService.Scan(Parcel2Go.TestTest.Entities.Enums.InventoryType.ServiceD);
            checkoutServiceBindingSource.ResetBindings(false);
            DisplayTotal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _checkoutService.Scan(Parcel2Go.TestTest.Entities.Enums.InventoryType.ServiceF);
            checkoutServiceBindingSource.ResetBindings(false);
            DisplayTotal();
        }

        private async void DisplayTotal()
        {
            var total = await _checkoutService.GetTotalPriceAsync();
            textBox1.Text = total.ToString("£#0.00");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NewTransaction();
        }
    }
}
