namespace PlantRedactor
{
    public partial class Form1 : Form
    {
        private const int _X = 10;
        private const int _Y = 4;
        private const string _url = "http://localhost:5236";
        public Form1()
        {
            InitializeComponent();
            PlantSelector.Items.AddRange(new string[] { "SunFlower", "Peashooter", "WallNut" });

            for (int i = 0; i < _Y; i++)
            {
                for (int j = 0; j < _X; j++)
                {
                    Button button = new Button()
                    {
                        Text = "X:" + (j + 1) + " Y:" + (i + 1),
                        Size = new Size(100, 100),
                        Location = new Point(100 * j, 100 * i),
                        Enabled = true
                    };
                    button.Click += Plant;

                    ButtonBox.Controls.Add(button);
                }
            }

        }

        private async void Plant(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string[] xY = button.Text.Split(" ");
            int x = int.Parse(xY[0].Remove(0, 2));
            int y = int.Parse(xY[1].Remove(0, 2));
            var _client = new HttpClient();
            string login = "";
            string password = "password";
            string email = "email";
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "apiKey", UserKey.Text },
                { "gameKey", GameKey.Text },
                { "X", x.ToString()},
                { "Y", y.ToString()},
                { "plantName", (string)PlantSelector.SelectedItem}
            };

            FormUrlEncodedContent contentBody = new FormUrlEncodedContent(body);
            HttpResponseMessage response = await _client.PostAsync(_url+@"/game/Plant", contentBody); 
            MessageBox.Show(await response.Content.ReadAsStringAsync());
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            return;

        }

        private void PlantSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonBox.Enabled = true;
        }
    }
}
