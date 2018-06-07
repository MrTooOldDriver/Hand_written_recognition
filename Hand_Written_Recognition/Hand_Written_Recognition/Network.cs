using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hand_Written_Recognition
{
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Windows;

    class Network
    {
        public void NetworkStartPoint()
        {
            
            
        }

        //Layer1 784 Neuron Input
        //Layer2 16 Neuron
        //Layer3 16 Neuron
        //Layer4 10 Neuron Output

        private double[][] Neurons(int LayerNumber,int[] Neutron)
        {
            if (LayerNumber == Neutron.Length)
            {


                double[][] initailDoubles = new double [LayerNumber][];
                for (int i = 0; i < LayerNumber; i++)
                {

                }

                return null;
            }
            else
            {
                MessageBox.Show("Error: Intput Layer number doesn't fir with Neutron[]");
                return null;
            }

        }
    }
}
