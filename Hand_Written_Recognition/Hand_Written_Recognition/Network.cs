using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hand_Written_Recognition
{
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Security.Cryptography;
    using System.Windows;
    using System.Windows.Documents;

    class Network
    {
        public void NetworkStartPoint()
        {
            this.initalInfo();
            double[][] Network = Neurons(4, cellinfo);
        }

        //Layer1 784 Neuron Input
        //Layer2 16 Neuron 32?
        //Layer3 16 Neuron
        //Layer4 10 Neuron Output

        int[] cellinfo = new int[4];
        private void initalInfo()
        {
            this.cellinfo[0] = 784;
            this.cellinfo[1] = 16;
            this.cellinfo[2] = 16;
            this.cellinfo[3] = 10;
        }


        private double[][] Neurons(int LayerNumber,int[] Neutron)
        {
            if (LayerNumber == Neutron.Length)
            {


                double[][] initailDoubles = new double [LayerNumber][];
                for (int i = 0; i < LayerNumber; i++)
                {
                    double[] inlayer = new double[Neutron[i]];
                    for (int j = 0; j < Neutron[i]; j++)
                    {
                        inlayer[j] = 0;

                    }

                    initailDoubles[i] = inlayer;
                }

                MessageBox.Show(initailDoubles[3].Length.ToString());
                return initailDoubles;
                //Using Neutrons[][] to access cell
                //Nutrons[0-3] is double[] contain cell number 
            }
            else
            {
                MessageBox.Show("Error: Intput Layer number doesn't fit with Neutron[]");
                return null;
            }

        }

        public void initalNumber(double[][] InputNetwork)
        {
            //Inital Network Number
        }

        public float randomAndConvert()
        {
            //random a number between 0 -100 and using e formula to convert it to 0 - 1 number 
            //
            return 1;
        }
    }

}
