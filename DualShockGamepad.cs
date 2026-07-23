using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;


namespace UnityEngine.InputSystem.DualShock
{
    /// <summary>
    /// A Sony DualShock/DualSense controller.
    /// </summary>
    [InputControlLayout(displayName = "PlayStation Controller")]
    public class DualShockGamepad : Gamepad, IDualShockHaptics
    {
        /// <summary>
        /// Button that is triggered when the touchbar on the controller is pressed down.
        /// </summary>
        /// <value>Control representing the touchbar button.</value>
        [InputControl(name = "buttonWest", displayName = "Square", shortDisplayName = "Square")]
        [InputControl(name = "buttonNorth", displayName = "Triangle", shortDisplayName = "Triangle")]
        [InputControl(name = "buttonEast", displayName = "Circle", shortDisplayName = "Circle")]
        [InputControl(name = "buttonSouth", displayName = "Cross", shortDisplayName = "Cross")]

		[InputControl]  public ButtonControl touchpadButton { get; protected set; }

        //[InputControl]  public ButtonControl micButton { get; protected set; }
       
        /// <summary>
        /// The right side button in the middle section of the controller. Equivalent to
        /// <see cref="Gamepad.startButton"/>.
        /// </summary>
        /// <value>Same as <see cref="Gamepad.startButton"/>.</value>
        [InputControl(name = "start", displayName = "Options")]
        public ButtonControl optionsButton { get; protected set; }

        /// <summary>
        /// The left side button in the middle section of the controller. Equivalent to
        /// <see cref="Gamepad.selectButton"/>
        /// </summary>
        /// <value>Same as <see cref="Gamepad.selectButton"/>.</value>
        [InputControl(name = "select", displayName = "Share")]
        public ButtonControl shareButton { get; protected set; }

        /// <summary>
        /// The left shoulder button.
        /// </summary>
        /// <value>Equivalent to <see cref="Gamepad.leftShoulder"/>.</value>
        [InputControl(name = "leftShoulder", displayName = "L1", shortDisplayName = "L1")]
        public ButtonControl L1 { get; protected set; }

        /// <summary>
        /// The right shoulder button.
        /// </summary>
        /// <value>Equivalent to <see cref="Gamepad.rightShoulder"/>.</value>
        [InputControl(name = "rightShoulder", displayName = "R1", shortDisplayName = "R1")]
        public ButtonControl R1 { get; protected set; }

        /// <summary>
        /// The left trigger button.
        /// </summary>
        /// <value>Equivalent to <see cref="Gamepad.leftTrigger"/>.</value>
        [InputControl(name = "leftTrigger", displayName = "L2", shortDisplayName = "L2")]
        public ButtonControl L2 { get; protected set; }

        /// <summary>
        /// The right trigger button.
        /// </summary>
        /// <value>Equivalent to <see cref="Gamepad.rightTrigger"/>.</value>
        [InputControl(name = "rightTrigger", displayName = "R2", shortDisplayName = "R2")]
        public ButtonControl R2 { get; protected set; }

        /// <summary>
        /// The left stick press button.
        /// </summary>
        /// <value>Equivalent to <see cref="Gamepad.leftStickButton"/>.</value>
        [InputControl(name = "leftStickPress", displayName = "L3", shortDisplayName = "L3")]
        public ButtonControl L3 { get; protected set; }

        /// <summary>
        /// The right stick press button.
        /// </summary>
        /// <value>Equivalent to <see cref="Gamepad.rightStickButton"/>.</value>
        [InputControl(name = "rightStickPress", displayName = "R3", shortDisplayName = "R3")]
        public ButtonControl R3 { get; protected set; }


		[InputControl(name = "gyroX", displayName = "Gyro X", shortDisplayName = "GX")]
		public AxisControl gyroX { get; protected set; }
		[InputControl(name = "gyroY", displayName = "Gyro Y", shortDisplayName = "GY")]
		public AxisControl gyroY { get; protected set; }
		[InputControl(name = "gyroZ", displayName = "Gyro Z", shortDisplayName = "GZ")]
		public AxisControl gyroZ { get; protected set; }


		[InputControl(name = "accelX", displayName = "Accelerometer X", shortDisplayName = "AX")] //Only used with DualSense
		public AxisControl accelX { get; protected set; }
		[InputControl(name = "accelY", displayName = "Accelerometer Y", shortDisplayName = "AY")]
		public AxisControl accelY { get; protected set; }
		[InputControl(name = "accelZ", displayName = "Accelerometer Z", shortDisplayName = "AZ")]
		public AxisControl accelZ { get; protected set; }


		[InputControl(name = "touch1X", displayName = "Touch 1X", shortDisplayName = "T1X")]
		public IntegerControl touch1X { get; protected set; }
		[InputControl(name = "touch1Y", displayName = "Touch 1Y", shortDisplayName = "T2Y")]
		public IntegerControl touch1Y { get; protected set; }


		[InputControl(name = "touch2X", displayName = "Touch 2X", shortDisplayName = "T2X")]
		public IntegerControl touch2X { get; protected set; }
		[InputControl(name = "touch2Y", displayName = "Touch 2Y", shortDisplayName = "T2Y")]
		public IntegerControl touch2Y { get; protected set; }


		[InputControl(name = "touch1ID", displayName = "Touch 1ID", shortDisplayName = "T1ID")] //Only used with DualShock, used to determine when the touchpad is touched and released
		public IntegerControl touch1ID { get; protected set; }
		[InputControl(name = "touch2ID", displayName = "Touch 2ID", shortDisplayName = "T2ID")]
		public IntegerControl touch2ID { get; protected set; }
		public IntegerControl touchActive { get; protected set; }
		[InputControl(name = "touchActive", displayName = "Touch Active", shortDisplayName = "TA")] //Only used with DualSense, used to determine if the touchpad is still being touched

		/// <summary>
		/// The last used/added DualShock controller.
		/// </summary
		/// <value>Equivalent to <see cref="Gamepad.leftTrigger"/>.</value>
		public new static DualShockGamepad current { get; private set; }

        /// <summary>
        /// If the controller is connected over HID, returns <see cref="HID.HID.HIDDeviceDescriptor"/> data parsed from <see cref="InputDeviceDescription.capabilities"/>.
        /// </summary>
        internal HID.HID.HIDDeviceDescriptor hidDescriptor { get; private set; }

        /// <inheritdoc />
        public override void MakeCurrent()
        {
            base.MakeCurrent();
            current = this;
        }

        /// <inheritdoc />
        protected override void OnRemoved()
        {
            base.OnRemoved();
            if (current == this)
                current = null;
        }

        /// <inheritdoc />
        protected override void FinishSetup()
        {
            base.FinishSetup();

			//micButton = GetChildControl<ButtonControl>("micButton");
            touchpadButton = GetChildControl<ButtonControl>("touchpadButton");
            optionsButton = startButton;
            shareButton = selectButton;

            L1 = leftShoulder;
            R1 = rightShoulder;
            L2 = leftTrigger;
            R2 = rightTrigger;
            L3 = leftStickButton;
            R3 = rightStickButton;

			gyroX = TryGetChildControl<AxisControl>("gyroX");
			gyroY = TryGetChildControl<AxisControl>("gyroY");
			gyroZ = TryGetChildControl<AxisControl>("gyroZ");

			accelX = TryGetChildControl<AxisControl>("accelX");
			accelY = TryGetChildControl<AxisControl>("accelY");
			accelZ = TryGetChildControl<AxisControl>("accelZ");

			touch1X = TryGetChildControl<IntegerControl>("touch1X");
			touch1Y = TryGetChildControl<IntegerControl>("touch1Y");

			touch2X = TryGetChildControl<IntegerControl>("touch2X");
			touch2Y = TryGetChildControl<IntegerControl>("touch2Y");

			touch1ID = TryGetChildControl<IntegerControl>("touch1ID"); //only used by dualshock4 to detect touchpad taps and release
			touch2ID = TryGetChildControl<IntegerControl>("touch2ID"); //only used by dualshock4 to detect touchpad taps and release with the second finger
			touchActive = TryGetChildControl<IntegerControl>("touchActive"); //only used by dualsense to detect touchpad taps, constantly changes while the touchpad is touched

			if (m_Description.capabilities != null && m_Description.interfaceName == "HID")
                hidDescriptor = HID.HID.HIDDeviceDescriptor.FromJson(m_Description.capabilities);
        }

        /// <inheritdoc />
        public virtual void SetLightBarColor(Color color)
        {
        }
    }
}
