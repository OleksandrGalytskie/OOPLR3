using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace OOPLR3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OceanFish Akula = new OceanFish();
            Akula.Info();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name;
            double mass;
            double cost;
            double lifetime;
            string country;
            name = Interaction.InputBox("назва риби");
            mass = Convert.ToDouble(Interaction.InputBox("Маса риби:"));
            cost = Convert.ToDouble(Interaction.InputBox("Ціна за кг:"));
            lifetime = Convert.ToDouble(Interaction.InputBox("Ця риба живе:"));
            country = Interaction.InputBox("Країна:");
            OceanFish Akula = new OceanFish(mass, name, cost, lifetime, country);
            Akula.Info();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Fish fishKaras = new Fish();
            fishKaras.Info();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RiverFish Som = new RiverFish();
            Som.Info();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name;
            double mass;
            double cost;
            double lifetime;
            string country;
            name = Interaction.InputBox("назва риби");
            mass = Convert.ToDouble(Interaction.InputBox("Маса риби:"));
            cost = Convert.ToDouble(Interaction.InputBox("Ціна за кг:"));
            lifetime = Convert.ToDouble(Interaction.InputBox("Ця риба живе:"));
            country = Interaction.InputBox("Країна:");
            RiverFish Som = new RiverFish(mass, name, cost, lifetime, country);
            Som.Info();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //виводимо інформацію за допомогою інтерпольованих рядків
            MessageBox.Show($"Поточна кількість обєктів: {Fish.count}", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class Fish
    {
        //поля классу
        public double mass;
        public string name;
        public double cost;
        static public int count = 0;
        public int nomer;

        //конструктор за замовчуванням 
        public Fish()
        {
            count++;
            nomer = count;
        }

        //конструктор з параметрами
        public Fish(double mass, string name, double cost)
        {
            this.mass = mass;
            this.name = name;
            this.cost = cost;

            count++;
            nomer = count;
        }

        //деструктор
        ~Fish()
        {
            MessageBox.Show($"Ваша риба №{this.nomer} знищується ", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            count--;
        }

        //методи
        public double GetFullPrice()
        {
            return mass * cost;
        }
        public string GetTypeSize()
        {
            if (mass <= 0)
            {
                return "Це не риба";
            }
            else
                if (mass <= 10)
            {
                return "Це маленька риба";
            }
            else
            {
                return "Це велика риба";
            }
        }

        virtual public void Info()
        {
            MessageBox.Show($"Ваша риба: {this.name} має вагу {this.mass} кг та коштує {this.cost} грн за кілограм.\nЦіна риби: {GetFullPrice()} грн. \nТип риби: {GetTypeSize()}.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    //наслідувані класи
    public class OceanFish : Fish
    {
        public double lifetime;
        public string country;

        public OceanFish() : base()
        {
            this.country = "Країна за замовчуванням";
        }
        public OceanFish(double mass, string name, double cost, double lifetime, string country) : base(mass, name, cost)
        {
            this.lifetime = lifetime;
            this.country = country;
        }
        public double HowManyMassFishGetPerYear()
        {
            return mass / lifetime;
        }
        public string CheckCountry()
        {
            if (country == "росія")
            {
                return "Рибу не купляємо!";
            }
            else
            {
                return "Можна купувати";
            }

        }

        // перевизначений метод
        override public void Info()
        {
            MessageBox.Show($"Ваша риба: {this.name} має вагу {this.mass} кг та коштує {this.cost} грн за кілограм.\nЦіна риби: " +
                $"{GetFullPrice()} грн. \nТип риби: {GetTypeSize()}.\nПриріст маси риби за рік: {HowManyMassFishGetPerYear()} кг.\nКраїна: {this.country}. {CheckCountry()}.\nЦя риба живе {lifetime} років.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class RiverFish : Fish
    {
        public double lifetime;
        public string country;

        public RiverFish() : base()
        {
            this.country = "Країна за замовчуванням";
        }
        public RiverFish(double mass, string name, double cost, double lifetime, string country) : base(mass, name, cost)
        {
            this.lifetime = lifetime;
            this.country = country;
        }
        public double HowManyMassFishGetPerYear()
        {
            return mass / lifetime;
        }
        public string CheckCountry()
        {
            if (country == "росія")
            {
                return "Рибу не купляємо!";
            }
            else
            {
                return "Можна купувати";
            }

        }
        override public void Info()
        {
            MessageBox.Show($"Ваша риба: {this.name} має вагу {this.mass} кг та коштує {this.cost} грн за кілограм.\nЦіна риби: " +
               $"{GetFullPrice()} грн. \nТип риби: {GetTypeSize()}.\nПриріст маси риби за рік: {HowManyMassFishGetPerYear()} кг.\nКраїна: {this.country}. {CheckCountry()}.\nЦя риба живе {lifetime} років.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}