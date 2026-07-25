# UnityInputSystem-Playstation-Gyro-Touchpad
DualShockGamepad.cs and DualShockGamepadHUD.cs are Unity C# scripts that make Gyro, Accelerometer, and the Touchpad work with PS4 and PS5 controllers in Unity's InputSystem. These files are usually located in the following folder in your project with the InputSystem package installed: Library/PackageCache/com.unity.inputsystem@1.8.2/InputSystem/Plugins/DualShock

The scripts/plugins here have been minimally modified from their original versions included with the InputSystem (1.8.2) package to expose the controller's gyro, accelerometers, and the touchpad values to DualShockGamepad.current in C# scripts. The InputSystem tested here was 1.8.2, but this will likely work with previous versions as only two files here were updated with the new InputControls. 

The InputSystem main folder will likely be in your project's Library/PackageCache folder by default, and while you can overwrite the originals, if you update the InputSystem package the updated files included here will be replaced by the originals again. You can instead use the Assets/Packages folder to retain the modifications by copying com.unity.inputsystem@1.8.2 folder there after you install via the Package Manager.

A sample project, tested in Unity 2022.3.22f1 with everything necessary to get this to work is provided in Releases -->

# UnityInputSystem-プレイステーション-ジャイロ-タッチパッド
DualShockGamepad.cs と DualShockGamepadHUD.cs は、ジャイロ、加速度計、タッチパッドを Unity の InputSystem で PS4 および PS5 コントローラーで動作させる Unity C# スクリプトです。これらのファイルは通常、InputSystem パッケージがインストールされているプロジェクト内の次のフォルダーにあります: Library/PackageCache/com.unity.inputsystem@1.8.2/InputSystem/Plugins/DualShock

ここのスクリプト/プラグインは、InputSystem (1.8.2) パッケージに含まれている元のバージョンから最小限に変更されており、コントローラーのジャイロ、加速度センサー、およびタッチパッドの値を C# スクリプトの DualShockGamepad.current に公開します。ここでテストしたInputSystemは1.8.2ですが、新しいInputControlsで更新されたファイルは2つだけなので、これは以前のバージョンでも動作する可能性があります。 

デフォルトでは、InputSystem メイン フォルダーはプロジェクトの Library/PackageCache フォルダー内にある可能性が高く、元のフォルダーを上書きすることはできますが、InputSystem パッケージを更新すると、ここに含まれる更新されたファイルは再び元のフォルダーに置き換えられます。代わりに、パッケージ マネージャー経由でインストールした後、Assets/Packages フォルダーを使用して com.unity.inputsystem@1.8.2 フォルダーをそこにコピーすることで、変更を保持できます。

Unity 2022.3.22f1 でテストされ、これを動作させるために必要なものがすべて含まれたサンプル プロジェクトが、リリース --> で提供されています。
