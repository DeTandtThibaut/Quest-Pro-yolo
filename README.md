# Yolov5Net
YOLOv5 object detection with ML.NET, ONNX

## Installation

Install OpenCVsharp4 and OpenCVSharp Runtime windows package from nuget

Run this line from Package Manager Console:

```
Install-Package Yolov5Net -Version 1.0.9
```

For CPU usage run this line from Package Manager Console:

```
Install-Package Microsoft.ML.OnnxRuntime -Version 1.9.0
```

For GPU usage run this line from Package Manager Console:

```
Install-Package Microsoft.ML.OnnxRuntime.Gpu -Version 1.9.0
```

CPU and GPU packages can't be installed together.


