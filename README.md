# UnityInputSystem-Playstation-Gyro-Touchpad
DualShockGamepad.cs and DualShockGamepadHUD.cs are Unity C# scripts that make Gyro, Accelerometer, and the Touchpad work with PS4 and PS5 controllers in Unity's InputSystem.

These scripts have been minimally modified from their original versions included with the InputSystem (1.8.2) package to expose the controller's gyro, accelerometers, and the touchpad values to DualShockGamepad.current in C# scripts. The InputSystem tested here was 1.8.2, but this will likely work with previous versions as only two files here updated with the new InputControls. These files are located in the following folder: InputSystem/Plugins/DualShock.

The InputSystem main folder will likely be in your project's Library/PackageCache folder by default, and while you can overwrite the originals if you update the InputSystem package the updated files included here will be replaced by the originals again. You can instead use the Assets/Packages folder to retain the modifications by copying com.unity.inputsystem@1.8.2 folder there after you install via the Package Manager.

A sample project, tested in Unity 2022.3.22f1 with everything necessary to get this to work is provided in Releases -->
