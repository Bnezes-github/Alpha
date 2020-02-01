using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace MarkManager01
{
    public partial class MarkManager2018 : Form 
    {
        
        public MarkManager2018()
        {
            InitializeComponent();
        }
        int indexRow;
        private object OpenFileDialog1; //exportdata

        private void Form2_Load(object sender, EventArgs e)
        {
            label16.Text = DateTime.Now.ToLongDateString(); //show date
            label15.Text = "Welcome to Mark Manager"; //title
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Insert//Typing validation /insert data to gridview view/error area color//
        {
            if (textBox1.Text == "") //validation empty fields
            {
                textBox1.BackColor = Color.LightPink;// show error area color in light pink
                MessageBox.Show("Student ID is required", "Validation Error");
                return;
            }
            else if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.LightPink;
                MessageBox.Show("Frist Name is required", "Validation Error");
                return;
            }
            else if (textBox3.Text == "")
            {
                textBox3.BackColor = Color.LightPink;
                MessageBox.Show("Last Name is required", "Validation Error");
                return;
            }
            else if (textBox4.Text == "")
            {
                textBox4.BackColor = Color.LightPink;
                MessageBox.Show("Email Address is required", "Validation Error");
                return;
            }
            else if (comboBox1.Text == "")
            {
                comboBox1.BackColor = Color.LightPink;
                MessageBox.Show("Course ID is required", "Validation Error");
                return;
            }
            else if (textBox6.Text == "")
            {
                textBox6.BackColor = Color.LightPink;
                MessageBox.Show("Coursework 1 value is required", "Validation Error");
                return;

            }
            else if (textBox7.Text == "")
            {
                textBox7.BackColor = Color.LightPink;
                MessageBox.Show("Coursework 2 value is required", "Validation Error");
                return;
            }
            else if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.LightPink;
                MessageBox.Show("Final Exam value is required", "Validation Error");
                return;
            }
            else if (textBox12.Text == "")
            {
                textBox12.BackColor = Color.LightPink;
                MessageBox.Show("Please Calculate results", "Validation Error");
                return;
            }
            else if (textBox10.Text == "")
            {
                textBox10.BackColor = Color.LightPink;
                MessageBox.Show("Please Calculate results", "Validation Error");
                return;
            }
            else if (textBox11.Text == "")
            {
                textBox11.BackColor = Color.LightPink;
                MessageBox.Show("Please Calculate results", "Validation Error");
                return;
            }

            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text,
               textBox6.Text, textBox7.Text, textBox5.Text, textBox12.Text, textBox10.Text, textBox11.Text); //insert data into gradeview
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)  //import file
        {
            {
                dataGridView1.RowHeadersVisible = true;  //view header
                var parsedData = new List<string[]>();
                using (var sr = new StreamReader(@"C:/Users/Public/EXPORT.csv"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] row = line.Split(',');
                        parsedData.Add(row);
                    }
                }
                dataGridView1.ColumnCount = 11;
                for (int i = 0; i < 11; i++)
                {
                    var sb = new StringBuilder(parsedData[0][1]);
                    sb.Replace('_', ' ');
                    sb.Replace("\"", "");
                    dataGridView1.Columns[i].Name = sb.ToString();
                }

                foreach (string[] row in parsedData)
                {
                    dataGridView1.Rows.Add(row);
                }
            }
     
            dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
        }

        private void button6_Click(object sender, EventArgs e)                      //counting grades from the box
        {
            try
            {
                Display.ClearSelected();
                for (int i = Display.Items.Count - 1; i >= 0; i++)
                {
                    if (Display.Items[i].ToString().Contains("A"))
                    {
                        Display.SetSelected(i, true);
                        chart1.Series["Grade"].Points.AddXY("Number of Grades", i + 1);  //load chart
                        break;
                    }
                    if (Display.Items[i].ToString().Contains("B"))
                    {
                        Display.SetSelected(i, true);
                        chart1.Series["Grade"].Points.AddXY("Number of Grades", i + 1);
                        break;
                    }
                    if (Display.Items[i].ToString().Contains("C"))
                    {
                        Display.SetSelected(i, true);
                        chart1.Series["Grade"].Points.AddXY("Number of Grades", i + 1);
                        break;
                    }
                    if (Display.Items[i].ToString().Contains("D"))
                    {
                        Display.SetSelected(i, true);
                        chart1.Series["Grade"].Points.AddXY("Number of Grades", i + 1);
                        break;
                    }
                    if (Display.Items[i].ToString().Contains("E"))
                    {
                        Display.SetSelected(i, true);
                        chart1.Series["Grade"].Points.AddXY("Number of Grades", i + 1);
                        break;
                    }
                    if (Display.Items[i].ToString().Contains("F"))
                    {
                        Display.SetSelected(i, true);
                        chart1.Series["Grade"].Points.AddXY("Number of Grades", i + 1);
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Char Error", "Validation Error");
            }
           
        }

        private void button11_Click(object sender, EventArgs e) //exit button // exit dialog
        {
            DialogResult iExitButton;
            iExitButton = MessageBox.Show("Would you like to Exit the application?", "Mark Manager 2018", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (iExitButton == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e) //calculate results using array/ validation
        {
            if (textBox6.Text == "")            //validation no value
            {
                textBox6.BackColor = Color.LightPink; // shows error area color
                MessageBox.Show("Coursework 1 score is required", "Validation Error");
                return;
            }
            else if (textBox7.Text == "")
            {
                textBox7.BackColor = Color.LightPink;
                MessageBox.Show("Coursework 2 score is required", "Validation Error");
                return;
            }
            else if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.LightPink;
                MessageBox.Show("Final Exam score is required", "Validation Error");
                return;
            }
            double[] calculateResults = new double[6];
            calculateResults[0] = Convert.ToDouble(textBox6.Text);
            calculateResults[1] = Convert.ToDouble(textBox7.Text);
            calculateResults[2] = Convert.ToDouble(textBox5.Text);  //geting number from textbox and conver to decimal numbers

            calculateResults[3] = (calculateResults[0] * 0.3) + (calculateResults[1] * 0.3) + (calculateResults[2] * 0.4); //calculating average (100x30%)+(100x30%)+(100x40%)
            calculateResults[4] = calculateResults[0] + calculateResults[1] + calculateResults[2];     // calculating total

            string calculateAverage = Convert.ToString(calculateResults[3]); //converting results to show in relevant textbox
            string calculateTotal = Convert.ToString(calculateResults[4]);

            textBox12.Text = calculateTotal; //show calculation on read only box both the grade and for listbox
            textBox10.Text = calculateAverage;

            if (calculateResults[3] >= 70 && calculateResults[3] <= 100)
            {
                textBox11.Text = "A";
                textBox8.Text = "A";
            }
            else if (calculateResults[3] >= 60 && calculateResults[3] <= 69)
            {
                textBox11.Text = "B";
                textBox8.Text = "B";
            }
            else if (calculateResults[3] >= 50 && calculateResults[3] <= 59)
            {
                textBox11.Text = "C";
                textBox8.Text = "C";
            }
            else if (calculateResults[3] >= 43 && calculateResults[3] <= 49)
            {
                textBox11.Text = "D";
                textBox8.Text = "D";
            }
            else if (calculateResults[3] >= 40 && calculateResults[3] <= 42)
            {
                textBox11.Text = "E";
                textBox8.Text = "D";
            }
            else if (calculateResults[3] >= 0 && calculateResults[3] <= 39)
            {
                textBox11.Text = "F";
                textBox8.Text = "F";
            }
            if (calculateResults[0] >= 101) // values to calculate should not be graeter then 100
            {
                MessageBox.Show("Coursework 1 Score Number Range from 0 to 100.", "Range Error");
            }
            else if (calculateResults[1] >= 101)
            {
                MessageBox.Show("Coursework 2 Score Number Range from 0 to 100.", "Range Error");
            }
            else if (calculateResults[2] >= 101)
            {
                MessageBox.Show("Final Exam Score Number Range from 0 to 100.", "Range Error");
            }

        }
            
        private void button4_Click(object sender, EventArgs e)                                                          
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();                                                                       //clear details 
            textBox8.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            comboBox1.ResetText();
            Display.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)                       // clear data from dataview dialog box yes clears data
        {
            DialogResult iClearButton;
            iClearButton = MessageBox.Show("Are you sure you want to Clear All Data?", "Reset Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iClearButton == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.RowHeadersVisible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)                    //delete row from data view
        {
            int g;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            else
            {          
                MessageBox.Show("Select a Row to Delete.", "Mark Manager 2018");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.BackColor = Color.White;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.BackColor = Color.LightGray;
        }

        private void button8_Click(object sender, EventArgs e)         //sorting data
        {
            dataGridView1.Sort(dataGridView1.Columns[10], ListSortDirection.Ascending);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Ascending);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
             textBox6.BackColor = Color.White;  
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.BackColor = Color.White;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.White;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox12.BackColor = Color.LightGray;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.BackColor = Color.LightGray;

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)                                                         // Insert only digit numbers Backspace and Delete keys work
            {
                e.Handled = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.RowHeadersVisible = false;                                                                     //removes row header before saving csv file
                dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;           //copies data to clip board               
                dataGridView1.SelectAll();                                                                               // Select all the cells
               
                DataObject dataObject = dataGridView1.GetClipboardContent();                                             // Copy selected cells to DataObject
                File.WriteAllText(@"C:/Users/Public/EXPORT.csv", dataObject.GetText(TextDataFormat.CommaSeparatedValue));

                MessageBox.Show("Data has been Exported", "Mark Manager 2018");
                dataGridView1.RowHeadersVisible = true;                                                             //shows row Header back in datagridview
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Table is empty. Please insert details", "Error Message");
            }
            dataGridView1.RowHeadersVisible = true;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];         //Select Row view back on textbox 
                textBox1.Text = row.Cells[0].Value.ToString();              //int index was declare on top as general int
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
                textBox5.Text = row.Cells[7].Value.ToString();
                textBox12.Text = row.Cells[8].Value.ToString();
                textBox10.Text = row.Cells[9].Value.ToString();
                textBox11.Text = row.Cells[10].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You cannot select this Cell!", "Mark Manager");
            }
                
        }

        private void BtnUp(object sender, EventArgs e) // update
        {
           
            try // if empty no error
            {
                DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];      //select row and update values
                newDataRow.Cells[0].Value = textBox1.Text;
                newDataRow.Cells[1].Value = textBox2.Text;
                newDataRow.Cells[2].Value = textBox3.Text;
                newDataRow.Cells[3].Value = textBox4.Text;
                newDataRow.Cells[4].Value = comboBox1.Text;
                newDataRow.Cells[5].Value = textBox6.Text;
                newDataRow.Cells[6].Value = textBox7.Text;
                newDataRow.Cells[7].Value = textBox5.Text;
                newDataRow.Cells[8].Value = textBox12.Text;
                newDataRow.Cells[9].Value = textBox10.Text;
                newDataRow.Cells[10].Value = textBox11.Text;

            }
            catch (Exception)
            {
                 MessageBox.Show("Data Table is empty. Please insert details", "Error Message"); 
            }
            
        }

        private void radioButton2_Click(object sender, EventArgs e)         // Radio button Click view for  degree
        {
            string degree = Convert.ToString(textBox11.Text);
            if (degree == "A" || degree == "1st")
            {
                textBox11.Text = "1st";
            }
            else if (degree == "B" || degree == "2:1")
            {
                textBox11.Text = "2:1";
            }
            else if (degree == "C" || degree == "2:2")
            {
                textBox11.Text = "2:2";
            }
            else if (degree == "D" || degree == "3rd")
            {
                textBox11.Text = "3rd";
            }
            else if (degree == "E" || degree == "Pass")
            {
                textBox11.Text = "Pass";
            }
            else if (degree == "F" || degree == "Fail")
            {
                textBox11.Text = "Fail";
            }
            else if (degree == "Error")
            {
                textBox11.Text = "Error";
            }

        }

        private void radioButton1_Click(object sender, EventArgs e)         // Radio button Click view
        {
            string letters = Convert.ToString(textBox11.Text);
            if (letters == "A" || letters == "1st")
            {
                textBox11.Text = "A";
            }
            else if (letters == "B" || letters == "2:1")
            {
                textBox11.Text = "B";
            }
            else if (letters == "C" || letters == "2:2")
            {
                textBox11.Text = "C";
            }
            else if (letters == "D" || letters == "3rd")
            {
                textBox11.Text = "D";
            }
            else if (letters == "E" || letters == "Pass")
            {
                textBox11.Text = "E";
            }
            else if (letters == "F" || letters == "Fail")
            {
                textBox11.Text = "F";
            }
            else if (letters == "Error")
            {
                textBox11.Text = "Error";
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)               // Insert only digit numbers Backspace and Delete keys work for textbox7 coursework1
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)               // Insert only digit numbers Backspace and Delete keys work for textbox5 coursework2
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)               // Insert only letters Backspace for textbox2 name
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)               // Insert only letters Backspace for textbox3
            {
                e.Handled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            //TextBox1.Text = ListBox1.Items.Count.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string countList = Convert.ToString(textBox8.Text); // insert grade latter from text box 8 to listbox
            if (countList =="A")
            {
                Display.Items.Add(textBox8.Text);
            }
            else if (countList == "B")
            {
                Display.Items.Add(textBox8.Text);
            }
            else if (countList == "C")
            {
                Display.Items.Add(textBox8.Text);
            }
            else if (countList == "D")
            {
                Display.Items.Add(textBox8.Text);
            }
            else if (countList == "E")
            {
                Display.Items.Add(textBox8.Text);
            }
            else if (countList == "F")
            {
                Display.Items.Add(textBox8.Text);
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Display_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {
           
        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}

