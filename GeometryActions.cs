#if AUTOMATIONTEST
using Common.Test.Automation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using static Common.Test.Automation.Session;

namespace Test.DesignIQAutomationUI.TestActions
{
    public class GeometryActions
    {
#region Table Indexes

        private const int TblNameIndex = 1;
        private const int TblXCoordIndex = 2;
        private const int TblYCoordIndex = 3;
        private const int TblSideIndex = 4;
        private const int TblTypeIndex = 5;
        private const int TblDiameterIndex = 6;
        private const int TblUnitsIndex = 7;
        private const int TblMoveableIndex = 8;
        private const int TblDiameterODIndex = 9;
        private const int TblRatioIndex = 10;
        private const int TblArcLengthIndex = 11;
        private const int TblWrapAngleIndex = 12;
        private const int TblSpanLengthIndex = 13;

#endregion

#region Button Indexes

        private const int BtnEditIdlerIndex = 2;
        private const int BtnAddPulleyIndex = 0;
        private const int BtnZoomToFit = 7;
        private const int BtnPivotedIdlerIndex = 9;
        private const int BtnSlottedIdlerIndex = 10;
        private const int BtnNoIdlerIndex = 11;

#endregion

#region WebElements

        private static IWebElement GeometryInputView { get; set; }
        private static IWebElement LeftPanel { get; set; }

        private static IWebElement TblComponents { get; set; }
        private static IList<IWebElement> TblComponentRows { get; set; }

#endregion

#region Resets

        public static void Reset()
        {
            var container = BaseActions.GetTileViewContainer("GeometryInputView");
            GeometryInputView = container;
            TblComponents = GeometryInputView.FindElement(ByWindowsAutomation.AccessibilityId("TblComponentRows"));
            ResetTblComponentRows();
            LeftPanel = GeometryInputView.FindElement(ByWindowsAutomation.AccessibilityId("LeftPanel"));
        }

        public static void ResetTblComponentRows()
        {
            TblComponentRows = TblComponents.FindElements(By.ClassName("DataGridRow"));
        }

#endregion

#region Button Clicks

        public static void ClickAddPulleyButton()
        {
            try
            {
                var buttons = LeftPanel.FindElements(By.ClassName("Button"));
                var addPulleyButton = buttons.ElementAt(BtnAddPulleyIndex);
                addPulleyButton.Click();
                ResetActions();
                UserActions.MoveByOffset(100, 0);
                UserActions.Click();
                UserActions.Perform();
            }
            catch (Exception ex)
            {
                var message = $"Problem with BtnAddPulley; Exception message: {ex.Message};";
                Console.WriteLine(message);
                Assert.Fail(message);
            }
        }

        public static void ClickZoomToFitButton()
        {
            try
            {
                var buttons = LeftPanel.FindElements(By.ClassName("Button"));
                var addPulleyButton = buttons.ElementAt(BtnZoomToFit);
                addPulleyButton.Click();
            }
            catch (Exception ex)
            {
                var message = $"Problem with BtnZoomToFit; Exception message: {ex.Message};";
                Console.WriteLine(message);
                Assert.Fail(message);
            }
        }

        public static void ClickEditIdlerButton()
        {
            try
            {
                var buttons = GeometryInputView.FindElements(By.ClassName("Button"));
                var editIdlerButton = buttons.ElementAt(BtnEditIdlerIndex);
                editIdlerButton.Click();
                TestSession.SwitchTo().Window(TestSession.WindowHandles[0]);
            }
            catch (Exception ex)
            {
                var message = $"Problem with BtnEditIdler; Exception message: {ex.Message};";
                Console.WriteLine(message);
                Assert.Fail(message);
            }
        }

        public static void ClickPivotedIdlerButton()
        {
            try
            {
                var buttons = LeftPanel.FindElements(By.ClassName("Button"));
                var setPivotedIdlerButton = buttons.ElementAt(BtnPivotedIdlerIndex);
                setPivotedIdlerButton.Click();
            }
            catch(Exception ex)
            {
                var message = $"Problem with BtnPivotedIdler; Exception message: {ex.Message};";
                Console.WriteLine(message);
                Assert.Fail(ex.Message);
            }
        }

        public static void ClickSlottedIdlerButton()
        {
            try
            {
                var buttons = LeftPanel.FindElements(By.ClassName("Button"));
                var setPivotedIdlerButton = buttons.ElementAt(BtnSlottedIdlerIndex);
                setPivotedIdlerButton.Click();
            }
            catch (Exception ex)
            {
                var message = $"Problem with BtnSlottedIdler; Exception message: {ex.Message};";
                Console.WriteLine(message);
                Assert.Fail(ex.Message);
            }
        }

        public static void ClickNoIdlerButton()
        {
            try
            {
                var buttons = LeftPanel.FindElements(By.ClassName("Button"));
                var setPivotedIdlerButton = buttons.ElementAt(BtnNoIdlerIndex);
                setPivotedIdlerButton.Click();
            }
            catch (Exception ex)
            {
                var message = $"Problem with BtnNoIdler; Exception message: {ex.Message};";
                Console.WriteLine(message);
                Assert.Fail(ex.Message);
            }
        }
        
#endregion

#region Pulley table values getters
       
        public static string GetPulleyName(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblNameIndex);
        }

        public static string GetPulleyXCoord(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblXCoordIndex);
        }

        public static string GetPulleyYCoord(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblYCoordIndex);
        }

        public static string GetPulleySide(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblSideIndex);
        }

        public static string GetPulleyType(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblTypeIndex);
        }

        public static string GetPulleyDiameter(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblDiameterIndex);
        }

        public static string GetPulleyUnits(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblUnitsIndex);
        }

        public static string GetPulleyMoveable(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblMoveableIndex);
        }

        public static string GetPulleyDiameterOD(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblDiameterODIndex);
        }

        public static string GetPulleyRatio(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblRatioIndex);
        }

        public static string GetPulleyArcLength(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblArcLengthIndex);
        }

        public static string GetPulleyWrapAngle(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblWrapAngleIndex);
        }

        public static string GetPulleySpanLength(int rowIndex)
        {
            return DataGridActions.GetGridTextValueByIndex(TblComponentRows, rowIndex, TblSpanLengthIndex);
        }
       
#endregion

#region Pulley table values setters
        
        public static void SetPulleyName(int rowIndex, string value)
        {
            DataGridActions.SetGridTextValueByIndex(TblComponentRows, rowIndex, TblNameIndex, value);
        }

        public static void SetPulleyXCoord(int rowIndex, string value)
        {
            DataGridActions.SetGridTextValueByIndex(TblComponentRows, rowIndex, TblXCoordIndex, value);
        }

        public static void SetPulleyYCoord(int rowIndex, string value)
        {
            DataGridActions.SetGridTextValueByIndex(TblComponentRows, rowIndex, TblYCoordIndex, value);
        }

        public static void SetPulleySide(int rowIndex, string value)
        {
            DataGridActions.SetGridDropDownValueByIndex(BaseActions.Window, TblComponentRows, rowIndex, TblSideIndex, value);
        }

        public static void SetPulleyType(int rowIndex, string value)
        { 
            DataGridActions.SetGridDropDownValueByIndex(BaseActions.Window, TblComponentRows, rowIndex, TblTypeIndex, value);
        }

        public static void SetPulleyDiameter(int rowIndex, string value)
        {
            DataGridActions.SetGridTextValueByIndexWithDoubleCick(TblComponentRows, rowIndex, TblDiameterIndex, value);
        }

        public static void SetPulleyMoveable(int rowIndex, string value)
        {
            DataGridActions.SetGridDropDownValueByIndex(BaseActions.Window, TblComponentRows, rowIndex, TblMoveableIndex, value);
        }

#endregion
    }
}
#endif