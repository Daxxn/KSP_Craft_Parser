﻿using PartDataReaderLibrary.CraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartDataReaderLibrary.Calculators
{
    public class CalcManager
    {
        #region - Fields & Properties
        public Craft Craft { get; set; }
        public CommunicationCalculator CommCalc { get; set; }
        public ElectricalCalculator ElectricalCalc { get; set; }
        public ThrustCalculator ThrustCalc { get; set; }
        public ScienceCalculator ScienceCalc { get; set; }
        #endregion

        #region Constructors
        public CalcManager( Craft craft )
        {
            ScienceCalc = new ScienceCalculator(craft);
            CommCalc = new CommunicationCalculator(craft);
            ElectricalCalc = new ElectricalCalculator(craft);
            ThrustCalc = new ThrustCalculator(craft);
        }
        #endregion

        #region - Methods
        public void Calculate( )
        {
            ScienceCalc.Calculate();
            CommCalc.Calculate();
            ElectricalCalc.Calculate();
            ThrustCalc.Calculate();
        }

        public void SecondCalculate( )
        {
            CommCalc.CalcHighestAntennaDraw(ScienceCalc.LargestFile);
            CommCalc.CalcTotalAntennaDraw(ScienceCalc.TotalData);
        }

        public void PrintData( )
        {
            StringBuilder builder = new StringBuilder("All Data :\n");
            builder.AppendLine(ScienceCalc.PrintData());
            builder.AppendLine();
            builder.AppendLine(CommCalc.PrintData());
            builder.AppendLine();
            builder.AppendLine(ElectricalCalc.PrintData());
            builder.AppendLine();
            builder.AppendLine(ThrustCalc.PrintData());
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
