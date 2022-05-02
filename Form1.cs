using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // загрузка данных
            tableInput.Rows.Clear();
            string filename = "C:/Users/bogda/OneDrive/Рабочий стол/инст/магистратура/2 семестр 1 курс/Алгоритмы на графах/Варианты/" + fileNameBox.Text +".txt";
            foreach (var line in File.ReadLines(filename))
            {
                var array = line.Split();
                tableInput.Rows.Add(array);
            }


            tableInput2.Rows.Clear(); 
            foreach (var line in File.ReadLines(filename))
            {
                var array = line.Split();
                tableInput2.Rows.Add(array);
            }

            tableInput21.Rows.Clear();
            foreach (var line in File.ReadLines(filename))
            {
                var array = line.Split();
                tableInput21.Rows.Add(array);
            }

            tableInput22.Rows.Clear();
            foreach (var line in File.ReadLines(filename))
            {
                var array = line.Split();
                tableInput22.Rows.Add(array);
            }

            tableInput23.Rows.Clear();
            foreach (var line in File.ReadLines(filename))
            {
                var array = line.Split();
                tableInput23.Rows.Add(array);
            }

            tableInput24.Rows.Clear();
            foreach (var line in File.ReadLines(filename))
            {
                var array = line.Split();
                tableInput24.Rows.Add(array);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            volenceBox.Clear();
            tableRib.Rows.Clear();
            tableRib2.Rows.Clear();
            ribBox.Clear();
            oBox.Clear();
            M1Box.Clear();
            M2Box.Clear();
            MIBox.Clear();
            int volence = 0; // степень вершины
            string rib = "";
            for (int n = 1; n <= Convert.ToInt32(NumBox.Text); n++) // перебор всех вершин от 1 до n
            {
                oBox.Text += "Окрестность вершины " + n + ": ";
                for (int i = 0; i < tableInput.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableInput[0, i].Value);
                    int i1 = Convert.ToInt32(tableInput[1, i].Value);
                    if (i0 == n || i1 == n)
                    {
                        MIBox.Text += " 1 ";
                        volence += 1;
                        rib = "( " + i0 + ", " + i1 + ")";
                        if (i1 == n)
                        {
                            oBox.Text += i0 + "; ";
                        }
                        if (i0 == n)
                        {
                            oBox.Text += i1 + "; ";
                        }
                    }
                    else
                    {
                        MIBox.Text += " 0 ";
                    }
                }


                //// для матрицы смежности вершин

                for (int m = 1; m <= Convert.ToInt32(NumBox.Text); m++)
                {
                    
                    bool o = false;
                    for (int i = 0; i < tableInput.RowCount - 1; i++)
                    {
                        int i0 = Convert.ToInt32(tableInput[0, i].Value);
                        int i1 = Convert.ToInt32(tableInput[1, i].Value);
                        if (i0 == n && i1 == m || i0 == m && i1 == n)
                        {
                            o = true;
                            M1Box.Text += " 1 ";
                            break;
                        }
                        
                    }
                    if (!o)
                    {
                        bool sos = false;
                        M1Box.Text += " 0 ";
                        // для дополнительного графа///////////////////////////////
                        if (n != m)
                        {
                            for (int k = 0; k < tableRib.RowCount-1; k++)
                            {
                                int k0 = Convert.ToInt32(tableRib[0, k].Value);
                                int k1 = Convert.ToInt32(tableRib[1, k].Value);
                                if (k0 == m && k1 == n) sos = true;
                            }
                            if(!sos) tableRib.Rows.Add(n,m);
                        }
                    }
                }

                M1Box.Text += Environment.NewLine;
                MIBox.Text += Environment.NewLine;
                volenceBox.Text += "Вершина "+ n + " имеет степень "+ volence + ";" + Environment.NewLine;
                if(volence == 1) ribBox.Text += "Вершина " + n + " висячая; " + Environment.NewLine + "Ребро " + rib + " висячее;" + Environment.NewLine;

                oBox.Text += Environment.NewLine;
                volence = 0;
            }
            //// для матрицы смежности ребер
            for (int j = 0; j < tableInput.RowCount - 1; j++)
            {
                int j0 = Convert.ToInt32(tableInput[0, j].Value);
                int j1 = Convert.ToInt32(tableInput[1, j].Value);

                oBox.Text += "Окрестность ребра (" + j0 + ", " + j1 + "): { ";

                for (int i = 0; i < tableInput.RowCount - 1; i++)
                {
                    bool sos2 = false;
                    int i0 = Convert.ToInt32(tableInput[0, i].Value);
                    int i1 = Convert.ToInt32(tableInput[1, i].Value);
                    if ((j0 == i0 || j0 == i1) && j1 != i0 && j1 != i1)
                    {
                        M2Box.Text += " 1 ";
                        oBox.Text += "(" + i0 + "," + i1 + ");";
                        ///////////////////////////////////// для реберного графа
                        for (int k = 0; k < tableRib2.RowCount - 1; k++)
                        {
                            NumBox2.Text = (k-1).ToString();
                            NumBox2.Text = (k -1).ToString();
                            NumBox2.Text = (k -1).ToString();
                            NumBox2.Text = (k -1).ToString();
                            NumBox2.Text = (k -1).ToString();
                            int k0 = Convert.ToInt32(tableRib2[0, k].Value);
                            int k1 = Convert.ToInt32(tableRib2[1, k].Value);
                            if (k0 == i+1 && k1 == j+1) sos2 = true;
                        }
                        if (!sos2) tableRib2.Rows.Add(j + 1, i + 1);


                    }
                    else if ((j1 == i0 || j1 == i1) && j0 != i0 && j0 != i1)
                    {
                        M2Box.Text += " 1 ";
                        oBox.Text += "(" + i0 + "," + i1 + ");";
                    }
                    else
                    {
                        M2Box.Text += " 0 ";
                    }
                }

                M2Box.Text += Environment.NewLine;
                oBox.Text += " }"+ Environment.NewLine;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            volenceBox1.Clear();
            ribBox1.Clear();
            oBox1.Clear();
            M1Box1.Clear();
            M2Box1.Clear();
            MIBox1.Clear();
            int volence = 0; // степень вершины
            string rib = "";
            for (int n = 1; n <= Convert.ToInt32(NumBox.Text); n++) // перебор всех вершин от 1 до n
            {
                oBox1.Text += "Окрестность вершины " + n + ": ";
                for (int i = 0; i < tableRib.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableRib[0, i].Value);
                    int i1 = Convert.ToInt32(tableRib[1, i].Value);
                    if (i0 == n || i1 == n)
                    {
                        MIBox1.Text += " 1 ";
                        volence += 1;
                        rib = "( " + i0 + ", " + i1 + ")";
                        if (i1 == n)
                        {
                            oBox1.Text += i0 + "; ";
                        }
                        if (i0 == n)
                        {
                            oBox1.Text += i1 + "; ";
                        }
                    }
                    else
                    {
                        MIBox1.Text += " 0 ";
                    }
                }


                //// для матрицы смежности вершин

                for (int m = 1; m <= Convert.ToInt32(NumBox.Text); m++)
                {

                    bool o = false;
                    for (int i = 0; i < tableRib.RowCount - 1; i++)
                    {
                        int i0 = Convert.ToInt32(tableRib[0, i].Value);
                        int i1 = Convert.ToInt32(tableRib[1, i].Value);
                        if (i0 == n && i1 == m || i0 == m && i1 == n)
                        {
                            o = true;
                            M1Box1.Text += " 1 ";
                            break;
                        }

                    }
                    if (!o)
                    {
                        M1Box1.Text += " 0 ";
                       
                    }
                }

                M1Box1.Text += Environment.NewLine;
                MIBox1.Text += Environment.NewLine;
                volenceBox1.Text += "Вершина " + n + " имеет степень " + volence + ";" + Environment.NewLine;
                if (volence == 1) ribBox1.Text += "Вершина " + n + " висячая; " + Environment.NewLine + "Ребро " + rib + " висячее;" + Environment.NewLine;

                oBox1.Text += Environment.NewLine;
                volence = 0;
            }
            //// для матрицы смежности ребер
            for (int j = 0; j < tableRib.RowCount - 1; j++)
            {
                int j0 = Convert.ToInt32(tableRib[0, j].Value);
                int j1 = Convert.ToInt32(tableRib[1, j].Value);

                oBox1.Text += "Окрестность ребра (" + j0 + ", " + j1 + "): { ";

                for (int i = 0; i < tableRib.RowCount - 1; i++)
                {

                    int i0 = Convert.ToInt32(tableRib[0, i].Value);
                    int i1 = Convert.ToInt32(tableRib[1, i].Value);
                    if ((j0 == i0 || j0 == i1) && j1 != i0 && j1 != i1)
                    {
                        M2Box1.Text += " 1 ";
                        oBox1.Text += "(" + i0 + "," + i1 + ");";
                    }
                    else if ((j1 == i0 || j1 == i1) && j0 != i0 && j0 != i1)
                    {
                        M2Box1.Text += " 1 ";
                        oBox1.Text += "(" + i0 + "," + i1 + ");";
                    }
                    else
                    {
                        M2Box1.Text += " 0 ";
                    }
                }

                M2Box1.Text += Environment.NewLine;
                oBox1.Text += " }" + Environment.NewLine;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            volenceBox2.Clear();
            ribBox2.Clear();
            oBox2.Clear();
            M1Box2.Clear();
            M2Box2.Clear();
            MIBox2.Clear();
            int volence = 0; // степень вершины
            string rib = "";
            for (int n = 1; n <= Convert.ToInt32(NumBox2.Text); n++) // перебор всех вершин от 1 до n
            {
                oBox2.Text += "Окрестность вершины " + n + ": ";
                for (int i = 0; i < tableRib2.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableRib2[0, i].Value);
                    int i1 = Convert.ToInt32(tableRib2[1, i].Value);
                    if (i0 == n || i1 == n)
                    {
                        MIBox2.Text += " 1 ";
                        volence += 1;
                        rib = "( " + i0 + ", " + i1 + ")";
                        if (i1 == n)
                        {
                            oBox2.Text += i0 + "; ";
                        }
                        if (i0 == n)
                        {
                            oBox2.Text += i1 + "; ";
                        }
                    }
                    else
                    {
                        MIBox2.Text += " 0 ";
                    }
                }


                //// для матрицы смежности вершин

                for (int m = 1; m <= Convert.ToInt32(NumBox2.Text); m++)
                {

                    bool o = false;
                    for (int i = 0; i < tableRib2.RowCount - 1; i++)
                    {
                        int i0 = Convert.ToInt32(tableRib2[0, i].Value);
                        int i1 = Convert.ToInt32(tableRib2[1, i].Value);
                        if (i0 == n && i1 == m || i0 == m && i1 == n)
                        {
                            o = true;
                            M1Box2.Text += " 1 ";
                            break;
                        }

                    }
                    if (!o)
                    {
                        M1Box2.Text += " 0 ";

                    }
                }

                M1Box2.Text += Environment.NewLine;
                MIBox2.Text += Environment.NewLine;
                volenceBox2.Text += "Вершина " + n + " имеет степень " + volence + ";" + Environment.NewLine;
                if (volence == 1) ribBox2.Text += "Вершина " + n + " висячая; " + Environment.NewLine + "Ребро " + rib + " висячее;" + Environment.NewLine;

                oBox2.Text += Environment.NewLine;
                volence = 0;
            }
            //// для матрицы смежности ребер
            for (int j = 0; j < tableRib2.RowCount - 1; j++)
            {
                int j0 = Convert.ToInt32(tableRib2[0, j].Value);
                int j1 = Convert.ToInt32(tableRib2[1, j].Value);

                oBox2.Text += "Окрестность ребра (" + j0 + ", " + j1 + "): { ";

                for (int i = 0; i < tableRib2.RowCount - 1; i++)
                {

                    int i0 = Convert.ToInt32(tableRib2[0, i].Value);
                    int i1 = Convert.ToInt32(tableRib2[1, i].Value);
                    if ((j0 == i0 || j0 == i1) && j1 != i0 && j1 != i1)
                    {
                        M2Box2.Text += " 1 ";
                        oBox2.Text += "(" + i0 + "," + i1 + ");";
                    }
                    else if ((j1 == i0 || j1 == i1) && j0 != i0 && j0 != i1)
                    {
                        M2Box2.Text += " 1 ";
                        oBox2.Text += "(" + i0 + "," + i1 + ");";
                    }
                    else
                    {
                        M2Box2.Text += " 0 ";
                    }
                }

                M2Box2.Text += Environment.NewLine;
                oBox2.Text += " }" + Environment.NewLine;
            }
        }
        /// lab 2
        /// 

        List<int> minPoint = new List<int>();
        List<int> point = new List<int>();
        string minRib = "";
        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            int[] volenceArray = new int[Convert.ToInt32(NumBox22.Text)];
            int value = Convert.ToInt32(NumBox22.Text);
            maxPointBox.Clear();
            int volence = 0; // степень вершины
            for (int n = 1; n <= Convert.ToInt32(NumBox22.Text); n++) // перебор всех вершин от 1 до n
            {
                for (int i = 0; i < tableInput21.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableInput21[0, i].Value);
                    int i1 = Convert.ToInt32(tableInput21[1, i].Value);
                    if (i0 == n || i1 == n)
                    {
                        volence += 1;
                    }
                }
                volenceArray[n - 1] = volence;
                volence = 0;
            }
            for (int t = 0; t < tableInput21.RowCount; t++)
            {
                if (tableInput21.RowCount > 1)
                {
                    for (int i = 0; i < volenceArray.Length - 1; i++)
                    {
                        if (volenceArray[i] == volenceArray.Max() && volenceArray[i] != 0)
                        {
                            for (int k = 0; k < tableInput21.RowCount - 1; k++)
                            {
                                int k0 = Convert.ToInt32(tableInput21[0, k].Value);
                                int k1 = Convert.ToInt32(tableInput21[1, k].Value);
                                if ((i + 1) == k0)
                                {
                                    tableInput21.Rows.RemoveAt(k);
                                    k = -1;
                                }
                                else if ((i + 1) == k1)
                                {
                                    tableInput21.Rows.RemoveAt(k);
                                    k = -1;
                                }
                            }
                            volenceArray[i] = 0;
                            minBox.Text += (i + 1) + ", ";
                            minPoint.Add(i + 1);
                            for (int n = 1; n <= Convert.ToInt32(NumBox22.Text); n++) // перебор всех вершин от 1 до n
                            {
                                for (int o = 0; o < tableInput21.RowCount - 1; o++)
                                {
                                    int i0 = Convert.ToInt32(tableInput21[0, o].Value);
                                    int i1 = Convert.ToInt32(tableInput21[1, o].Value);
                                    if (i0 == n || i1 == n)
                                    {
                                        volence += 1;
                                    }
                                }
                                volenceArray[n - 1] = volence;
                                volence = 0;
                            }
                            //break;
                        }

                    }
                }
            }
            // min point
            for (int i = 1; i <= value; i++)
            {
                if (!minPoint.Contains(i)) maxPointBox.Text += i + ", ";
            }

            //////////
            ///
            // max par
            if (tableInput22.RowCount != 1)
            {
                volence = 0; // степень вершины
                for (int n = 1; n <= value; n++) // перебор всех вершин от 1 до n
                {
                    for (int i = 0; i < tableInput22.RowCount - 1; i++)
                    {
                        int i0 = Convert.ToInt32(tableInput22[0, i].Value);
                        int i1 = Convert.ToInt32(tableInput22[1, i].Value);
                        if (i0 == n || i1 == n)
                        {
                            volence += 1;
                        }
                    }
                    volenceArray[n - 1] = volence;
                    volence = 0;
                }

                for (int n = 0; n < volenceArray.Length; n++)
                {
                    if (volenceArray[n] == 0) volenceArray[n] = 10;
                }

                for (int k = 0; k < tableInput22.RowCount - 1; k++)
                {
                    int k0 = Convert.ToInt32(tableInput22[0, k].Value);
                    int k1 = Convert.ToInt32(tableInput22[1, k].Value);
                    if (volenceArray[k1 - 1] == volenceArray.Min() || volenceArray[k0 - 1] == volenceArray.Min())
                    {
                        point.Add(k1);
                        point.Add(k0);
                        maxTwoBox.Text += "( " + k0 + ", " + k1 + " )";
                        minRib += "( " + k0 + ", " + k1 + " )";
                        tableInput22.Rows.RemoveAt(k);
                        for (int a = 0; a < tableInput22.RowCount; a++)
                        {
                            int ka0 = Convert.ToInt32(tableInput22[0, a].Value);
                            int ka1 = Convert.ToInt32(tableInput22[1, a].Value);
                            if ((ka1 == k1 && ka0 != k0) || (ka1 != k1 && ka0 == k0)
                                || (ka1 == k0 && ka0 != k1) || (ka1 != k0 && ka0 == k1))
                            {
                                tableInput22.Rows.RemoveAt(a);
                                a = -1;
                                k = -1;
                            }
                        }
                        for (int n = 1; n <= value; n++) // перебор всех вершин от 1 до n
                        {
                            for (int i = 0; i < tableInput22.RowCount - 1; i++)
                            {
                                int i0 = Convert.ToInt32(tableInput22[0, i].Value);
                                int i1 = Convert.ToInt32(tableInput22[1, i].Value);
                                if (i0 == n || i1 == n)
                                {
                                    volence += 1;
                                }
                            }
                            volenceArray[n - 1] = volence;
                            volence = 0;
                        }
                        for (int n = 0; n < volenceArray.Length; n++)
                        {
                            if (volenceArray[n] == 0) volenceArray[n] = 10;
                        }
                    }
                }
            }

            //////////
            ///

            // min reb
            for (int p = 1; p <= value; p++)
            {
                if (!point.Contains(p))
                {
                    for (int i = tableInput2.RowCount - 1; i >= 0; i--)
                    {
                        int i0 = Convert.ToInt32(tableInput2[0, i].Value);
                        int i1 = Convert.ToInt32(tableInput2[1, i].Value);
                        if (p == i0 || p == i1)
                        {
                            minRibBox.Text += minRib + "( " + i0 + ", " + i1 + " )";
                            break;
                        }
                    }
                }
            }
            if (tableInput23.RowCount != 1)
            {
                // min domin point
                volence = 0; // степень вершины
                for (int n = 1; n <= value; n++) // перебор всех вершин от 1 до n
                {
                    for (int i = 0; i < tableInput23.RowCount - 1; i++)
                    {
                        int i0 = Convert.ToInt32(tableInput23[0, i].Value);
                        int i1 = Convert.ToInt32(tableInput23[1, i].Value);
                        if (i0 == n || i1 == n)
                        {
                            volence += 1;
                        }
                    }
                    volenceArray[n - 1] = volence;
                    volence = 0;
                }

                List<int> volenceList = new List<int>();
                // min domin rib
                for (int t = 0; t < tableInput23.RowCount - 1; t++)
                {
                    volence = 0;
                    int t0 = Convert.ToInt32(tableInput23[0, t].Value);
                    int t1 = Convert.ToInt32(tableInput23[1, t].Value);
                    for (int ta = 0; ta < tableInput23.RowCount - 1; ta++)
                    {

                        int ta0 = Convert.ToInt32(tableInput23[0, ta].Value);
                        int ta1 = Convert.ToInt32(tableInput23[1, ta].Value);
                        if (((t0 == ta0 || t0 == ta1) || (t1 == ta0 || t1 == ta1)
                            && ((t0 == ta0 && t1 != ta1) || (t1 == ta1 || t0 != ta0))))
                        {
                            volence++;
                        }
                    }
                    volenceList.Add(volence);
                }
                for (int t = 0; t < tableInput23.RowCount - 1; t++)
                {
                    int t0 = Convert.ToInt32(tableInput23[0, t].Value);
                    int t1 = Convert.ToInt32(tableInput23[1, t].Value);
                    if (volenceList[t] == volenceList.Max())
                    {
                        minDomRibBox.Text += " (" + t0 + ", " + t1 + ") ";
                        if (volenceArray[t0 - 1] == volenceArray.Max())
                        {
                            minDomPointBox.Text += t0 + ", ";
                        }
                        else if (volenceArray[t1 - 1] == volenceArray.Max())
                        {
                            minDomPointBox.Text += t1 + ", ";
                        }
                        for (int ta = 0; ta < tableInput23.RowCount - 1; ta++)
                        {
                            int ta0 = Convert.ToInt32(tableInput23[0, ta].Value);
                            int ta1 = Convert.ToInt32(tableInput23[1, ta].Value);
                            if (t0 == ta0 || t0 == ta1 || t1 == ta0 || t1 == ta1)
                            {
                                tableInput23.Rows.RemoveAt(ta);
                                ta--;
                                t = -1;
                            }
                        }
                        volenceList.Clear();
                        //пересчет степеней
                        for (int u = 0; u < tableInput23.RowCount - 1; u++)
                        {
                            volence = 0;
                            int u0 = Convert.ToInt32(tableInput23[0, u].Value);
                            int u1 = Convert.ToInt32(tableInput23[1, u].Value);
                            for (int ta = 0; ta < tableInput23.RowCount - 1; ta++)
                            {

                                int ta0 = Convert.ToInt32(tableInput23[0, ta].Value);
                                int ta1 = Convert.ToInt32(tableInput23[1, ta].Value);
                                if (((u0 == ta0 || u0 == ta1) || (u1 == ta0 || u1 == ta1)
                                    && ((u0 == ta0 && u1 != ta1) || (u1 == ta1 || u0 != ta0))))
                                {
                                    volence++;
                                }
                            }
                            volenceList.Add(volence);
                        }
                        for (int n = 1; n <= value; n++) // перебор всех вершин от 1 до n
                        {
                            for (int i = 0; i < tableInput23.RowCount - 1; i++)
                            {
                                int i0 = Convert.ToInt32(tableInput23[0, i].Value);
                                int i1 = Convert.ToInt32(tableInput23[1, i].Value);
                                if (i0 == n || i1 == n)
                                {
                                    volence += 1;
                                }
                            }
                            volenceArray[n - 1] = volence;
                            volence = 0;
                        }

                    }
                }
                }

                ///color point
                ///
                int[] colorArray = new int[7];
                string[] colorColor = new string[7];
                for(int i = 0; i < colorArray.Length; i++)
                {
                    colorArray[i] = 0;
                }
                List<int> colorPoints = new List<int>();
                for (int i = 1; i <= value; i++)
                {
                    colorPoints.Clear();
                    for(int k = 0; k < tableInput24.RowCount; k++)
                    {
                        int k0 = Convert.ToInt32(tableInput24[0, k].Value);
                        int k1 = Convert.ToInt32(tableInput24[1, k].Value);

                        if (i == k0)
                        {
                            colorPoints.Add(colorArray[k1-1]);
                        }
                        else if(i == k1)
                        {
                            colorPoints.Add(colorArray[k0-1]);
                        }
                    }
                    if (!colorPoints.Contains(1))
                    {
                        colorArray[i - 1] = 1;
                        colorColor[i - 1] = "Вршина " + i + " красная";
                    }
                    else if (!colorPoints.Contains(2))
                    {
                        colorArray[i - 1] = 2;
                        colorColor[i - 1] = "Вршина " + i + " зеленая";
                    }
                    else if (!colorPoints.Contains(3))
                    {
                        colorArray[i - 1] = 3;
                        colorColor[i - 1] = "Вршина " + i + " желтая";
                    }
                    else if (!colorPoints.Contains(4))
                    {
                        colorArray[i - 1] = 4;
                        colorColor[i - 1] = "Вршина " + i + " синяя";
                    }
                }
                for (int i = 0; i < colorArray.Length; i++)
                {
                    colorPointBox.Text += colorColor[i] + Environment.NewLine;
                }

                //////// 
                /// color rib

                int[] colorArrayRib = new int[tableInput24.RowCount - 1];
                string[] colorRib = new string[tableInput24.RowCount - 1];
                for (int i = 0; i < colorArrayRib.Length; i++)
                {
                    colorArrayRib[i] = 0;
                }
                List<int> colorPointsRib = new List<int>();
                for (int i = 0; i < tableInput24.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableInput24[0, i].Value);
                    int i1 = Convert.ToInt32(tableInput24[1, i].Value);

                    colorPointsRib.Clear();
                    for (int k = 0; k < tableInput24.RowCount; k++)
                    {
                        int k0 = Convert.ToInt32(tableInput24[0, k].Value);
                        int k1 = Convert.ToInt32(tableInput24[1, k].Value);
                        
                        if ((i0 == k0 || i0 == k1) && i1!= k0 && i1 != k1)
                        {
                            colorPointsRib.Add(colorArrayRib[k]);
                        }
                        else if ((i1 == k1 || i1 == k1) && i0 != k0 && i0 != k1)
                        {
                            colorPointsRib.Add(colorArrayRib[k]);
                        }
                    }
                    if (!colorPointsRib.Contains(1))
                    {
                        colorArrayRib[i] = 1;
                        colorRib[i] = "Ребро " + i0 + "," + i1 + " красное";
                    }
                    else if (!colorPointsRib.Contains(2))
                    {
                        colorArrayRib[i] = 2;
                        colorRib[i] = "Ребро " + i0 + "," + i1 + " зеленое";
                    }
                    else if (!colorPointsRib.Contains(3))
                    {
                        colorArrayRib[i] = 3;
                        colorRib[i] = "Ребро " + i0 + "," + i1 + " желтое";
                    }
                    else if (!colorPointsRib.Contains(4))
                    {
                        colorArrayRib[i] = 4;
                        colorRib[i] = "Ребро " + i0 + "," + i1 + " синее";
                    }
                    else if (!colorPointsRib.Contains(5))
                    {
                        colorArrayRib[i] = 5;
                        colorRib[i] = "Ребро " + i0 + "," + i1 + " фиолетовое";
                    }
                    else if (!colorPointsRib.Contains(6))
                    {
                        colorArrayRib[i] = 6;
                        colorRib[i] = "Ребро " + i0 + "," + i1 + " оранживое";
                    }
                }
                for (int i = 0; i < colorArrayRib.Length; i++)
                {
                    colorRibBox.Text += colorRib[i] + Environment.NewLine;
                }

            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            finally
            {
                MessageBox.Show("Говнище собралось");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //степени вершин
            int[] volenceArray = new int[Convert.ToInt32(NumBox22.Text)];
            int value = Convert.ToInt32(NumBox22.Text);
            volenceBox22.Clear();
            int volence = 0; // степень вершины
            for (int n = 1; n <= value; n++) // перебор всех вершин от 1 до n
            {
                for (int i = 0; i < tableInput2.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableInput2[0, i].Value);
                    int i1 = Convert.ToInt32(tableInput2[1, i].Value);
                    if (i0 == n || i1 == n)
                    {
                        volence += 1;
                    }
                }
                volenceArray[n - 1] = volence;
                volenceBox22.Text += "Вершина " + n + " имеет степень " + volence + ";" + Environment.NewLine;
                volence = 0;
            }
        }


        private void tableInput23_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
