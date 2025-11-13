using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Class_Object
{
    internal class Bearing
    {
        // attributes or properties or parameters or members
          public string typeBearing;
        public string materialBearing;
          public double ODBearing;
         public double thicknessBearing;
         public string applnBearing;
         public string applnPressure;
        public string sealing;

        //functions or member functions or methods 

        //member functions
        //setter
        public void ChangeBearingOD(double bearingOD)
        {
            ODBearing = bearingOD;
        }
        //getter
        public double getBearingOD()
        {
            return ODBearing;
        }
                
    }

    internal class BearingObjects
    { 
    static void Main(string[] args)
    {
        Bearing B26A005 = new Bearing { };
        B26A005.applnBearing = "Pneumatic";
        B26A005.typeBearing = "Open Type";
        B26A005.ODBearing = 26;
        B26A005.thicknessBearing = 2.4;
        B26A005.materialBearing = "Brass";
        B26A005.sealing = "none";

        Debug.Print(B26A005.ODBearing.ToString());

        B26A005.ChangeBearingOD(26.2);

        Debug.Print(B26A005.ODBearing.ToString());

        Bearing B26A005S = new Bearing { };
        B26A005S.applnBearing = "Pneumatic";
        B26A005S.typeBearing = "Open Type with Seal";
        B26A005S.ODBearing = 26;
        B26A005S.thicknessBearing = 2.4;
        B26A005S.materialBearing = "Brass";
        B26A005S.sealing = "Rubber Seal";


        Debug.Print(B26A005.typeBearing);
        Debug.Print(B26A005.applnBearing);
        Debug.Print(B26A005.ODBearing.ToString());


    }
    }
}
