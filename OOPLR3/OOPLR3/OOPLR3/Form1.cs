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
            name = Interaction.InputBox("����� ����");
            mass = Convert.ToDouble(Interaction.InputBox("���� ����:"));
            cost = Convert.ToDouble(Interaction.InputBox("ֳ�� �� ��:"));
            lifetime = Convert.ToDouble(Interaction.InputBox("�� ���� ����:"));
            country = Interaction.InputBox("�����:");
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
            name = Interaction.InputBox("����� ����");
            mass = Convert.ToDouble(Interaction.InputBox("���� ����:"));
            cost = Convert.ToDouble(Interaction.InputBox("ֳ�� �� ��:"));
            lifetime = Convert.ToDouble(Interaction.InputBox("�� ���� ����:"));
            country = Interaction.InputBox("�����:");
            RiverFish Som = new RiverFish(mass, name, cost, lifetime, country);
            Som.Info();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //�������� ���������� �� ��������� ��������������� �����
            MessageBox.Show($"������� ������� �����: {Fish.count}", "�����!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class Fish
    {
        //���� ������
        public double mass;
        public string name;
        public double cost;
        static public int count = 0;
        public int nomer;

        //����������� �� ������������� 
        public Fish()
        {
            count++;
            nomer = count;
        }

        //����������� � �����������
        public Fish(double mass, string name, double cost)
        {
            this.mass = mass;
            this.name = name;
            this.cost = cost;

            count++;
            nomer = count;
        }

        //����������
        ~Fish()
        {
            MessageBox.Show($"���� ���� �{this.nomer} ��������� ", "�����!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            count--;
        }

        //������
        public double GetFullPrice()
        {
            return mass * cost;
        }
        public string GetTypeSize()
        {
            if (mass <= 0)
            {
                return "�� �� ����";
            }
            else
                if (mass <= 10)
            {
                return "�� �������� ����";
            }
            else
            {
                return "�� ������ ����";
            }
        }

        virtual public void Info()
        {
            MessageBox.Show($"���� ����: {this.name} �� ���� {this.mass} �� �� ����� {this.cost} ��� �� �������.\nֳ�� ����: {GetFullPrice()} ���. \n��� ����: {GetTypeSize()}.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    //��������� �����
    public class OceanFish : Fish
    {
        public double lifetime;
        public string country;

        public OceanFish() : base()
        {
            this.country = "����� �� �������������";
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
            if (country == "����")
            {
                return "���� �� ��������!";
            }
            else
            {
                return "����� ��������";
            }

        }

        // �������������� �����
        override public void Info()
        {
            MessageBox.Show($"���� ����: {this.name} �� ���� {this.mass} �� �� ����� {this.cost} ��� �� �������.\nֳ�� ����: " +
                $"{GetFullPrice()} ���. \n��� ����: {GetTypeSize()}.\n������ ���� ���� �� ��: {HowManyMassFishGetPerYear()} ��.\n�����: {this.country}. {CheckCountry()}.\n�� ���� ���� {lifetime} ����.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class RiverFish : Fish
    {
        public double lifetime;
        public string country;

        public RiverFish() : base()
        {
            this.country = "����� �� �������������";
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
            if (country == "����")
            {
                return "���� �� ��������!";
            }
            else
            {
                return "����� ��������";
            }

        }
        override public void Info()
        {
            MessageBox.Show($"���� ����: {this.name} �� ���� {this.mass} �� �� ����� {this.cost} ��� �� �������.\nֳ�� ����: " +
               $"{GetFullPrice()} ���. \n��� ����: {GetTypeSize()}.\n������ ���� ���� �� ��: {HowManyMassFishGetPerYear()} ��.\n�����: {this.country}. {CheckCountry()}.\n�� ���� ���� {lifetime} ����.", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}