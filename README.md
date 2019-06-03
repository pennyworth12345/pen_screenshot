This is an Arma 3 extension to take screenshots of your display. This extension was created as a substitute to using the `screenshot` command, as for many it produces washed out images.

# Usage

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
