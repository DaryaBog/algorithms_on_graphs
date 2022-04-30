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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            volenceBox.Clear();
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
            //NumBox2.Text = Convert.ToString(tableRib2.RowCount - 1);
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
            int[] vol = new int[Convert.ToInt32(NumBox22.Text)];
            int value = Convert.ToInt32(NumBox22.Text);
            volenceBox22.Clear();
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
                vol[n-1] = volence;
                volenceBox22.Text += "Вершина " + n + " имеет степень " + volence + ";" + Environment.NewLine;
                volence = 0;
            }
            for(int t = 0; t < tableInput21.RowCount; t++) 
            {
                if (tableInput21.RowCount > 1)
                {
                    for (int i = 0; i < vol.Length - 1; i++)
                    {
                        if (vol[i] == vol.Max())
                        {
                            for (int k = 0; k < tableInput21.RowCount - 1; k++)
                            {
                                int k0 = Convert.ToInt32(tableInput21[0, k].Value);
                                int k1 = Convert.ToInt32(tableInput21[1, k].Value);
                                if ((i + 1) == k0)
                                {
                                    tableInput21.Rows.RemoveAt(k);
                                    k--;
                                }
                                else if ((i + 1) == k1)
                                {
                                    tableInput21.Rows.RemoveAt(k);
                                    k--;
                                }
                            }
                            vol[i] = 0;
                            volenceBox22.Text += (i + 1) + " уд ";
                            minBox.Text += (i + 1) + ", ";
                            minPoint.Add(i + 1);
                            break;
                        }

                    }
                }
            }
            // min point
            for(int i = 1; i <= value; i++)
            {
                if (!minPoint.Contains(i)) maxPointBox.Text += i +", ";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // max par

            int[] vol2 = new int[Convert.ToInt32(NumBox22.Text)];
            int volence2 = 0; // степень вершины
            for (int n = 1; n <= Convert.ToInt32(NumBox22.Text); n++) // перебор всех вершин от 1 до n
            {
                for (int i = 0; i < tableInput22.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableInput22[0, i].Value);
                    int i1 = Convert.ToInt32(tableInput22[1, i].Value);
                    if (i0 == n || i1 == n)
                    {
                        volence2 += 1;
                    }
                }
                vol2[n - 1] = volence2;
                volence2 = 0;
            }

            for (int n = 0; n < vol2.Length; n++)
            {
                if (vol2[n] == 0)
                {
                    vol2[n] = 10;
                }
            }

            
            for (int k = 0; k < tableInput22.RowCount; k++)
            {
                int k0 = Convert.ToInt32(tableInput22[0, k].Value);
                int k1 = Convert.ToInt32(tableInput22[1, k].Value);
                {
                    if(vol2[k1 - 1] == vol2.Min() || vol2[k0 - 1] == vol2.Min())
                    {
                        point.Add(k1);
                        point.Add(k0);
                        maxTwoBox.Text += "( " + k0 + ", " + k1 + " )";
                        //if (tableInput22.RowCount <= 3) // на всякий случай
                        //{
                        //    for (int end = 0; end < tableInput22.RowCount-1; end++)
                        //    {
                        //        int e0 = Convert.ToInt32(tableInput22[0, end].Value);
                        //        int e1 = Convert.ToInt32(tableInput22[1, end].Value);
                        //        minRibBox.Text += "( " + e0 + ", " + e1 + " )";
                        //    }
                        //    tableInput22.Rows.Clear();
                        //    break;
                        //}
                        minRib += "( " + k0 + ", " + k1 + " )";
                        vol2[k1 - 1] = 0;
                        vol2[k0 - 1] = 0;
                        tableInput22.Rows.RemoveAt(k);
                        for (int a = 0; a < tableInput22.RowCount; a++)
                        {
                            int ka0 = Convert.ToInt32(tableInput22[0, a].Value);
                            int ka1 = Convert.ToInt32(tableInput22[1, a].Value);
                            if ( (ka1 == k1 && ka0 != k0) || (ka1 != k1 && ka0 == k0) || (ka1 == k0 && ka0 != k1) || (ka1 != k0 && ka0 == k1))
                            {
                                tableInput22.Rows.RemoveAt(a);
                                a--;
                            }
                        }

                        break;
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int[] vol2 = new int[Convert.ToInt32(NumBox22.Text)];
            int value2 = Convert.ToInt32(NumBox22.Text);
            volenceBox22.Clear();
            maxTwoBox.Clear();
            int volence2 = 0; // степень вершины
            for (int n = 1; n <= Convert.ToInt32(NumBox22.Text); n++) // перебор всех вершин от 1 до n
            {
                for (int i = 0; i < tableInput22.RowCount - 1; i++)
                {
                    int i0 = Convert.ToInt32(tableInput22[0, i].Value);
                    int i1 = Convert.ToInt32(tableInput22[1, i].Value);
                    if (i0 == n || i1 == n)
                    {
                        volence2 += 1;
                    }
                }
                vol2[n - 1] = volence2;
                volenceBox22.Text += "Вершина " + n + " имеет степень " + volence2 + ";" + Environment.NewLine;
                volence2 = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // min reb
            int value = Convert.ToInt32(NumBox22.Text);
            for (int p = 1; p <= value; p++)
            {
                if (!point.Contains(p))
                {
                    for (int i = tableInput2.RowCount-1; i >= 0 ; i--)
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
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // min domin point
            int[] vol = new int[Convert.ToInt32(NumBox22.Text)];
            int value = Convert.ToInt32(NumBox22.Text);
            maxPointBox.Clear();
            int volence = 0; // степень вершины
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
                vol[n - 1] = volence;
                volence = 0;
            }
            for (int t = 0; t < tableInput23.RowCount; t++)
            {
                int t0 = Convert.ToInt32(tableInput23[0, t].Value);
                int t1 = Convert.ToInt32(tableInput23[1, t].Value);
                if(vol[t0-1] == vol.Max())
                {
                    minDomPointBox.Text += t0 + ", ";
                    for (int i = 0; i < tableInput23.RowCount; i++)
                    {
                        int i0 = Convert.ToInt32(tableInput23[0, i].Value);
                        int i1 = Convert.ToInt32(tableInput23[1, i].Value);
                        if(t0 == i0||t0 == i1)
                        {
                            tableInput23.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (vol[t1-1] == vol.Max())
                {
                    minDomPointBox.Text += t1 + ", ";
                    for (int i = 0; i < tableInput23.RowCount; i++)
                    {
                        int i0 = Convert.ToInt32(tableInput23[0, i].Value);
                        int i1 = Convert.ToInt32(tableInput23[1, i].Value);
                        if (t1 == i0 || t1 == i1)
                        {
                            tableInput23.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }
    }
}
