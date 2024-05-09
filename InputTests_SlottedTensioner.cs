#if AUTOMATIONTEST
using Common.Test.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Test.DesignIQAutomationUI.TestActions;
using static Common.Test.Automation.Session;

namespace Test.DesignIQAutomationUI
{
    [TestClass]
    public class InputTests_SlottedTensioner
    {
        [TestMethod]
        public void InputTest_SlottedTensioner()
        {
            try
            {
                BaseActions.CreateNewDesign();
                BaseActions.OpenDesignIQ();

                BeltTypeSelector_InputTests();
                Geometry_InputTests();
                CustomerInput_InputTests();
                LoadEntry_InputTests();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        public static void CustomerInput_InputTests()
        {
            GeneralActions.OpenCustomerInput();
            CustomerInputActions.Reset();

            CustomerInputActions.SetCustomerCompany("Company");
            CustomerInputActions.SetCustomerTitle("Title");
            CustomerInputActions.SetCustomerFirstName("First Name");
            CustomerInputActions.SetCustomerAddress1("Address 1");
            CustomerInputActions.SetCustomerPhone("Phone");
            CustomerInputActions.SetCustomerFax("Fax");
            CustomerInputActions.SetDriveDescription("Drive description");

            BaseActions.CloseTileView();
        }

        public static void BeltTypeSelector_InputTests()
        {
            BeltTypeSelectorActions.Reset();

            BeltTypeSelectorActions.SetBelt(new BeltTypeSelectorActions.Belt(
                "Synchronous", "Poly Chain GT Carbon", "8MGT"));
        }

        public static void Geometry_InputTests()
        {
            GeometryActions.Reset();
            GeometryActions.ClickAddPulleyButton();
            GeometryActions.Reset();

            GeometryInputPulley[] pulleys =
            {
                new GeometryInputPulley("0.00", "0.00", "Inside", "Grooves", "31", "Fixed"),
                new GeometryInputPulley("734.89", "0.00", "Inside", "Grooves", "99", "Slotted"),
            };

            for (int pulleyIndex = 0; pulleyIndex < pulleys.Length; pulleyIndex++)
            {
                GeometryActions.SetPulleyXCoord(pulleyIndex, pulleys[pulleyIndex].XCoord);
                GeometryActions.SetPulleyYCoord(pulleyIndex, pulleys[pulleyIndex].YCoord);
                GeometryActions.SetPulleySide(pulleyIndex, pulleys[pulleyIndex].Side);
                GeometryActions.SetPulleyType(pulleyIndex, pulleys[pulleyIndex].Type);
                GeometryActions.SetPulleyDiameter(pulleyIndex, pulleys[pulleyIndex].Diameter);
                GeometryActions.SetPulleyMoveable(pulleyIndex, pulleys[pulleyIndex].Moveable);
            }

            GeometryActions.ClickZoomToFitButton();

            BaseActions.CloseTileView();
        }

        public static void LoadEntry_InputTests()
        {
            GeneralActions.OpenLoadEntry();
            LoadEntryActions.CloseDialogBox();
            Thread.Sleep(1000);
            SelectBeltLengthActions.Reset();
            SelectBeltLengthActions.ClickOk();
            Thread.Sleep(1000);
            LoadEntryActions.Reset();
            LoadEntryActions.ResetConditionOptionsView();
            LoadEntryActions.ResetTblConditionOptions();
            Thread.Sleep(1000);

            LoadEntryConditionOptions[] options =
            {
                new LoadEntryConditionOptions("1", "10"),
                new LoadEntryConditionOptions("2", "1"),
                new LoadEntryConditionOptions("3", "5"),
                new LoadEntryConditionOptions("4", "8"),
                new LoadEntryConditionOptions("5", "10"),
                new LoadEntryConditionOptions("6", "15"),
                new LoadEntryConditionOptions("7", "20"),
                new LoadEntryConditionOptions("8", "15"),
                new LoadEntryConditionOptions("9", "10"),
                new LoadEntryConditionOptions("10", "5"),
                new LoadEntryConditionOptions("11", "1"),
            };

            //First condition is already created, just need to set correct time
            LoadEntryActions.SetConditionOptionsTblTime(0, options[0].Time);

            for (int optionIndex = 1; optionIndex < options.Length; optionIndex++)
            {
                LoadEntryActions.ResetTblConditionOptions();
                LoadEntryActions.AddCondition(options[optionIndex].Name);
                LoadEntryActions.ResetTblConditionOptions();
                LoadEntryActions.ScroollDownTo(optionIndex);
                LoadEntryActions.SetConditionOptionsTblTime(optionIndex, options[optionIndex].Time);
            }

            Thread.Sleep(1000);
            //Just some extra move to save the time value of last condition. Doesn't work without it
            //because of that bug when we need to click only on this table to save value in cell.
            LoadEntryActions.ResetTblConditionOptions();
            LoadEntryActions.SetConditionOptionsTblTimeSingleClick(options.Length / 2, options[options.Length / 2].Time);
            Thread.Sleep(1000);

            LoadEntryActions.Reset();
            int conditionTblIndex = 1;
            LoadEntryCondition[] conditions =
            {
                new LoadEntryCondition("Condition 1", "CW", "189.00", "Torque Units", "484.0"),
                new LoadEntryCondition("Condition 2", "CW", "975.00", "Torque Units", "145.0"),
                new LoadEntryCondition("Condition 3", "CW", "151.00", "Torque Units", "445.0"),
                new LoadEntryCondition("Condition 4", "CW", "237.00", "Torque Units", "284.0"),
                new LoadEntryCondition("Condition 5", "CW", "357.00", "Torque Units", "222.0"),
                new LoadEntryCondition("Condition 6", "CW", "396.00", "Torque Units", "230.0"),
                new LoadEntryCondition("Condition 7", "CW", "499.00", "Torque Units", "183.0"),
                new LoadEntryCondition("Condition 8", "CW", "549.00", "Torque Units", "177.0"),
                new LoadEntryCondition("Condition 9", "CW", "669.00", "Torque Units", "145.0"),
                new LoadEntryCondition("Condition 10", "CW", "728.00", "Torque Units", "144.0"),
                new LoadEntryCondition("Condition 11", "CW", "789.00", "Torque Units", "146.0"),
            };

            for (int conditionIndex = 0; conditionIndex < conditions.Length; conditionIndex++)
            {
                LoadEntryActions.SwitchCondition(conditions[conditionIndex].Name);
                LoadEntryActions.ResetTblCondition();
                LoadEntryActions.SetConditionTblDir(conditionTblIndex, conditions[conditionIndex].Dir);
                LoadEntryActions.SetConditionTblRPM(conditionTblIndex, conditions[conditionIndex].RPM);
                LoadEntryActions.SetConditionTblType(conditionTblIndex, conditions[conditionIndex].Type);
                LoadEntryActions.SetConditionTblLoad(conditionTblIndex, conditions[conditionIndex].Load);
                Thread.Sleep(1500);
            }

            Thread.Sleep(5000);

            BaseActions.CloseTileView();
            Thread.Sleep(1000);
            GeneralActions.OpenLoadEntry();

            LoadEntryActions.Reset();
            Thread.Sleep(3000);
            LoadEntryActions.SwitchToDiagnosticsTab();

            Thread.Sleep(10000);

            Assert.AreEqual("1", LoadEntryActions.GetHighestFatCond(), $"HighestFatCond not equal.");
            Assert.AreEqual("1", LoadEntryActions.GetHighestFatPulley(), $"HighestFatPulley not equal.");

            LoadEntryActions.ResetTblSectionSensitivity();
            int sectionSensitivityTableIndex = 0;
            Assert.AreEqual("Poly Chain GT Carbon 8MGT", LoadEntryActions.GetSectionSensitivityTblSection(sectionSensitivityTableIndex), $"Section SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex};");
            Assert.AreEqual("21.00", LoadEntryActions.GetSectionSensitivityTblBeltWidth(sectionSensitivityTableIndex), $"BeltWidth SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex};");
            Assert.AreEqual("1,040.76", LoadEntryActions.GetSectionSensitivityTblFatigueRate(sectionSensitivityTableIndex), $"FatigueRate SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex};");
            Assert.AreEqual("3984", LoadEntryActions.GetSectionSensitivityTblHours(sectionSensitivityTableIndex), $"Hours SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex}");

            sectionSensitivityTableIndex++;
            Assert.AreEqual("Poly Chain GT Carbon 14MGT", LoadEntryActions.GetSectionSensitivityTblSection(sectionSensitivityTableIndex), $"Section SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex};");
            Assert.AreEqual("0.00", LoadEntryActions.GetSectionSensitivityTblBeltWidth(sectionSensitivityTableIndex), $"BeltWidth SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex};");
            Assert.AreEqual("\u221E", LoadEntryActions.GetSectionSensitivityTblFatigueRate(sectionSensitivityTableIndex), $"FatigueRate SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex};");
            Assert.AreEqual("3984", LoadEntryActions.GetSectionSensitivityTblHours(sectionSensitivityTableIndex), $"Hours SectionSensitivityTable not equal. Section Sensitivity index: {sectionSensitivityTableIndex};");

            LoadEntryActions.ResetTblDriveSensitivity();
            int driveSensitivityTableIndex = 0;
            Assert.AreEqual("Increasing Pulley PD", LoadEntryActions.GetDriveTblFactor(driveSensitivityTableIndex), $"Factor DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");
            Assert.AreEqual("200.00 %", LoadEntryActions.GetDriveTblEffect(driveSensitivityTableIndex), $"Effect DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");

            driveSensitivityTableIndex++;
            Assert.AreEqual("Increasing Pulley Load", LoadEntryActions.GetDriveTblFactor(driveSensitivityTableIndex), $"Factor DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");
            Assert.AreEqual("100.00 %", LoadEntryActions.GetDriveTblEffect(driveSensitivityTableIndex), $"Effect DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");

            driveSensitivityTableIndex++;
            Assert.AreEqual("Increasing Driver Speed", LoadEntryActions.GetDriveTblFactor(driveSensitivityTableIndex), $"Factor DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");
            Assert.AreEqual("-400.00 %", LoadEntryActions.GetDriveTblEffect(driveSensitivityTableIndex), $"Effect DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");

            driveSensitivityTableIndex++;
            Assert.AreEqual("Increasing Belt Width", LoadEntryActions.GetDriveTblFactor(driveSensitivityTableIndex), $"Factor DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");
            Assert.AreEqual("200.00 %", LoadEntryActions.GetDriveTblEffect(driveSensitivityTableIndex), $"Effect DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");

            driveSensitivityTableIndex++;
            Assert.AreEqual("Increasing DTR", LoadEntryActions.GetDriveTblFactor(driveSensitivityTableIndex), $"Factor DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");
            Assert.AreEqual("-200.00 %", LoadEntryActions.GetDriveTblEffect(driveSensitivityTableIndex), $"Effect DriveSensitivityTable not equal. Drive Sensitivity index: {driveSensitivityTableIndex};");


            LoadEntryActions.SwitchToLoadInfoTab();
            LoadEntryActions.CheckDeflectionKnown();
            Assert.AreEqual("172.69", LoadEntryActions.GetNewMin(), $"NewMin (Deflfection Known) not equal.");
            Assert.AreEqual("187.35", LoadEntryActions.GetNewMax(), $"NewMax (Deflfection Known) not equal.");
            Assert.AreEqual("128.71", LoadEntryActions.GetOldMin(), $"OldMin (Deflfection Known) not equal.");
            Assert.AreEqual("143.37", LoadEntryActions.GetOldMax(), $"OldMax (Deflfection Known) not equal.");
            LoadEntryActions.CheckForceKnown();
            Assert.AreEqual("11.82", LoadEntryActions.GetNewMin(), $"NewMin (Force Known) not equal.");
            Assert.AreEqual("11.00", LoadEntryActions.GetNewMax(), $"NewMax (Force Known) not equal.");
            Assert.AreEqual("14.97", LoadEntryActions.GetOldMin(), $"OldMin (Force Known) not equal.");
            Assert.AreEqual("13.80", LoadEntryActions.GetOldMax(), $"OldMax (Force Known) not equal.");

            LoadEntryActions.SetTensionerType("Sonic Tension Meter");
            LoadEntryActions.CheckHz();
            Assert.AreEqual("110.8", LoadEntryActions.GetNewMin(), $"NewMin (Hz) not equal.");
            Assert.AreEqual("115.7", LoadEntryActions.GetNewMax(), $"NewMax (Hz) not equal.");
            Assert.AreEqual("94.5", LoadEntryActions.GetOldMin(), $"OldMin (Hz) not equal.");
            Assert.AreEqual("100.2", LoadEntryActions.GetOldMax(), $"OldMax (Hz) not equal.");
            LoadEntryActions.CheckTension();
            Assert.AreEqual("2579.93", LoadEntryActions.GetNewMin(), $"NewMin (Tension) not equal.");
            Assert.AreEqual("2814.47", LoadEntryActions.GetNewMax(), $"NewMax (Tension) not equal.");
            Assert.AreEqual("1876.32", LoadEntryActions.GetOldMin(), $"OldMin (Tension) not equal.");
            Assert.AreEqual("2110.86", LoadEntryActions.GetOldMax(), $"OldMax (Tension) not equal.");


            LoadEntryActions.SetTensionerType("Tensioner Force/Torque");
            Assert.AreEqual("5123.93", LoadEntryActions.GetNewMin(), $"NewMin (Tension) not equal.");
            Assert.AreEqual("5589.75", LoadEntryActions.GetNewMax(), $"NewMax (Tension) not equal.");
            Assert.AreEqual("3726.50", LoadEntryActions.GetOldMin(), $"OldMin (Tension) not equal.");
            Assert.AreEqual("4192.31", LoadEntryActions.GetOldMax(), $"OldMax (Tension) not equal.");

            Assert.AreEqual("8.00", LoadEntryActions.GetGroovedPulley(), $"GroovedPulley not equal.");
            Assert.AreEqual("2.00", LoadEntryActions.GetFlatPulley(), $"FlatPulley not equal.");

            Assert.AreEqual("2345.39", LoadEntryActions.GetStaticTensionPerBelt(), $"StaticTensionPerBelt not equal.");
            Assert.AreEqual("2345.39", LoadEntryActions.GetTotalStaticTension(), $"TotalStaticTension not equal.");

            LoadEntryActions.CheckWidthInput();
            Assert.AreEqual("21.00", LoadEntryActions.GetBeltWidth(), $"BeltWidth not equal.");

            BaseActions.CloseTileView();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            SynchronizationWait();
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            SynchronizationRelease();
            TearDown();
        }

        class GeometryInputPulley
        {
            public string XCoord { get; private set; }
            public string YCoord { get; private set; }
            public string Side { get; private set; }
            public string Type { get; private set; }
            public string Diameter { get; private set; }
            public string Moveable { get; private set; }

            public GeometryInputPulley(string XCoord, string YCoord, 
                string Side, string Type, string Diameter, string Moveable)
            {
                this.XCoord = XCoord;
                this.YCoord = YCoord;
                this.Side = Side;
                this.Type = Type;
                this.Diameter = Diameter;
                this.Moveable = Moveable;
            }
        }

        class LoadEntryConditionOptions
        {
            public string Name { get; private set; }
            public string Time { get; private set; }

            public LoadEntryConditionOptions(string Name, string Time)
            {
                this.Name = Name;
                this.Time = Time;
            }
        }

        class LoadEntryCondition
        {
            public string Name { get; private set; }
            public string Dir { get; private set; }
            public string RPM { get; private set; }
            public string Type { get; private set; }
            public string Load { get; private set; }

            public LoadEntryCondition(string Name, string Dir, string RPM, string Type, string Load)
            {
                this.Name = Name;
                this.Dir = Dir;
                this.RPM = RPM;
                this.Type = Type;
                this.Load = Load;
            }
        }
    }
}
#endif