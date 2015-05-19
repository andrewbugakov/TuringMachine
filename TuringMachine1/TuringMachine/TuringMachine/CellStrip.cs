using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    class CellStrip
    {
        
        Cell[] cstrip=new Cell[50];
        private int _positionX=0;
        private int _positionY=150;
        private int _stripLength = 50;//20, 150
        public CellStrip()
        {
            
            for(int i=0;i<cstrip.Length;i++)
            {
                Point p = new Point(_positionX+30*i, _positionY);
                Cell c=new Cell("",i,p);
                cstrip[i] = c;
            }
        }
        
        public CellStrip(int len)
        {
            cstrip = new Cell[len];
            for (int i = 0; i < cstrip.Length; i++)
            {
                Point p = new Point(_positionX + 30 * i, _positionY);
                Cell c = new Cell("", i, p);
                cstrip[i] = c;
            }
        }
        public void GenerateCellStrip(int num1,int num2)
        {

            for (int i = 0; i < num1+1+num2; i++)
            {
                if((i<num1)|(i>num1))
                cstrip[i].setText("*");//cell symbol of alphabet
                else cstrip[i].setText(",");//symbol of parse number  
            }
            
        }
        public void GenerateCellStrip(int num1)
        {
            for (int i = 0; i < cstrip.Length; i++)
            {

                cstrip[i].setText("");//cell symbol of alphabet
            }
            for (int i = 0; i < num1 ; i++)
            {
                
                    cstrip[i].setText("*");//cell symbol of alphabet
            }

        }
        public void GenerateCellStrip()
        {
            for (int i = 0; i < cstrip.Length; i++)
            {

                cstrip[i].setText("");//cell symbol of alphabet
            }
        }
        public void MoveEndorHome(bool val)
        {
            if (val)
            {
                for(int i=0;i<cstrip.Length;i++)
                {
                    cstrip[i].setPosition(0 + 30 * i);
                }
            }
            else
            {
                for (int i = 0; i < cstrip.Length; i++)
                {
                    cstrip[cstrip.Length-i-1].setPosition(600 - 30 * i);
                }
            }
        }

        public Cell[] getCellstrip()
        {
            return cstrip;
        }
        public void MoveLeft()
        {
            foreach (Cell cl in cstrip)
            {
                cl.setPosCell(true);
            }
        }
        public void MoveRight()
        {

            foreach (Cell cl in cstrip)
            {
                cl.setPosCell(false);
            }
        }

        public void SumStrip()
        {
            int sumcount=0;
            foreach (Cell c in cstrip)
            {
                if (c.getText() == "*")
                {
                    sumcount++;
                }
            }
            GenerateCellStrip(sumcount);
        }
    }
}
