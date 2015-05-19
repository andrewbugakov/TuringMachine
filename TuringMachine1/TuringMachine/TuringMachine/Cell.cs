using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    class Cell
    {
        private TextBox content;
        public Label numberofcell;
        private GroupBox grbxcell;
        private Point position;
        //private int position;
        //private bool selected;
        public Cell(string content,int numberofcell,Point p)
        {
            this.content = new TextBox();

            this.content.Text=content;
            this.content.Top = 10;
            this.content.Left = 5;
            this.content.Width = 20;
            this.content.Height = 13;
            //this.content.Location = p;
            //this.content.BackColor=(Color.Black);
            this.numberofcell = new Label();
            this.numberofcell.Text = Convert.ToString(numberofcell);
            //this.numberofcell.Location = p;
            this.grbxcell = new GroupBox();
           // this.grbxcell.Controls.Add(this.numberofcell);
           // this.grbxcell.Controls.Add(this.content);
            this.numberofcell.Top = 40;
            this.numberofcell.Left = 8;
            this.numberofcell.Width = 20;
            this.numberofcell.Height = 13;
            //this.numberofcell.BackColor=System.Drawing.Color.Black;//new System.Windows.Forms.Control[] { this.content,this.numberofcell  }
            this.grbxcell.Controls.AddRange(new System.Windows.Forms.Control[] { this.content, this.numberofcell });
            ////this.grbxcell.BackColor = System.Drawing.Color.Black;
            this.grbxcell.Height = 60;
            this.grbxcell.Width = 30;
            position = p;
            this.grbxcell.Location=position;
            
            
        }
        public void setPosCell(bool moverange)
        {
            if (moverange)
            {
                position.X += 30;
                grbxcell.Location = position;
            }
            else
            {
                position.X -= 30;
                grbxcell.Location = position;
            }
        }
        public TextBox gettextbox()
        {
            return content;
        }
        public Label getLabel()
        {
            return numberofcell;
        }
        public void setLabel(string textl)
        {
            numberofcell.Text=textl;
        }
        public void setText(string textl)
        {
            content.Text = textl;
        }
        public string getText()
        {
            return content.Text;
            
        }
        public GroupBox getgroup()
        {
            return grbxcell;
        }
        public Point getPosition()
        {
            return position;
        }
        public void setPosition(int posX)
        {
            position.X = posX;
            grbxcell.Location=position;
        }
        public void setAsSelected()
        {

        }
    }
}
