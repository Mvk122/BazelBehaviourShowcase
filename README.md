# How to see the behaviour

```
bazel build "//SecondPackage:SecondPackage"
```

Expected error message:
```
FirstPackage\Program.cs(9,9): error CS0433: The type 'JsonSerializerOptions' exists in both 'System.Text.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' and 'System.Text.Json, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
Target //SecondPackage:SecondPackage failed to build
```

This can be "resolved" by removing  `"@paket.mygroup//System.Text.Json:system.text.json"` from the BUILD.bazel file of FirstPackage.
However we don't want to do that as that will make it use the version 6 system.text.json.

We also cannot just upgrade SecondPackage to using System.Text.Json 7.0.0 either because that will conflict with the System.Text.Json 6.0.0 that it automatically imports.

A real solution would be to remove these "default" imports or just use the most recent version of the dependency for all packages. (which is likely what msbuild is doing).