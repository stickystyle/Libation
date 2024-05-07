﻿using System.Windows.Forms;

namespace LibationWinForms
{
    public class AccessibleDataGridViewButtonCell : DataGridViewButtonCell
    {
        protected string AccessibilityName
        {
            get => MyAccessibilityObject.AccessibilityName;
            set => MyAccessibilityObject.AccessibilityName = value;
        }

        /// <summary>
        /// Get or set description for accessibility. eg: screen readers. Also sets the ToolTipText
        /// </summary>
        protected string AccessibilityDescription
        {
            get => MyAccessibilityObject.AccessibilityDescription;
            set
            {
                MyAccessibilityObject.AccessibilityDescription = value;
                MyAccessibilityObject.Owner.ToolTipText = value;
            }
        }

        protected ButtonCellAccessibilityObject MyAccessibilityObject { get; set; }
        protected override AccessibleObject CreateAccessibilityInstance() => MyAccessibilityObject;

        public AccessibleDataGridViewButtonCell(string accessibilityName) : base()
        {
            MyAccessibilityObject = new(this, name: accessibilityName, description: "");
        }

        protected class ButtonCellAccessibilityObject : DataGridViewButtonCellAccessibleObject
        {
            public string AccessibilityName { get; set; }
            public string AccessibilityDescription { get; set; }

            public override string Name => AccessibilityName;
            public override string Description => AccessibilityDescription;

            public ButtonCellAccessibilityObject(DataGridViewCell owner, string name, string description) : base(owner)
            {
                AccessibilityName = name;
                AccessibilityDescription = description;
            }
        }
    }
}
