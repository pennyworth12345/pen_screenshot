This is an Arma 3 extension to take screenshots of your display. This extension was created as a substitute to using the `screenshot` command, as for many it produces washed out images.

[To grab the latest DLLs visit the release page.](https://github.com/pennyworth12345/pen_screenshot/releases/tag/v1.0.0)

# Usage
**This extension is not whitelisted by BattleEye, therefore when trying to use it you will need to disable BattleEye.** The DLLs can be placed either in the root of your Arma 3 directory (where the arma3 executables are located), or within an @modName folder.


### Capture
Captures your primary display at its native resolution with whatever is currently on the screen. To use, run either of the following in SQF:
```
// will capture an image in the same directory as the Arma executable
// with the name SomeFileName, and type fileType
"pen_screenshot" callExtension "capture:SomeFileName.fileType"

// will capture an image in the specified directory, and type fileType
"pen_screenshot" callExtension "capture:C:\path\to\some\place.fileType"
```
If the extension successfully captured an image, the `callExtension` command will return `"Success: Image saved"`. If it failed, it will return a message stating why it may have failed. If you specify a full path to a different directory, then that directory must already exist.

### Configure
Saved for future use to define properties of the image.
