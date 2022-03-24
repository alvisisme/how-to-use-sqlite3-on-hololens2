# How to use sqlite3 on Hololens2

本工程主要展示了如何在 HoloLens 2 设备上使用 sqlite3 数据库的方法。

## 测试环境

1. Unity 2020.3.28f1c1
1. HoloLens 2 ARM64
1. Target SDK Version 10.0.19041.0
1. Visual Studio Version 2019

## 依赖环境

1. sqlite 3.38.1 源码
1. sqlite-net 源码

## 主要步骤

1. 导入 sqlite3 源码，同时修改源码加入预编译指令`SQLITE_OS_WINRT`

    ```c
    /*
    ** Determine if we are dealing with WinRT, which provides only a subset of
    ** the full Win32 API.
    */
    // #if !defined(SQLITE_OS_WINRT) && !defined(PLATFORM_WINRT)
    // # define SQLITE_OS_WINRT 0
    // #endif

    # define SQLITE_OS_WINRT 1
    ```

    目前没有找到从 Unity 中控制 C/C++ 源码预编译指令的方法。

1. 导入支持 IL2CPP 的 sqlite-net 源码 SQLite.cs

    参考 [Support source code integration of sqlite3 for Unity IL2CPP](https://github.com/praeclarum/sqlite-net/pull/1104)

## 参考引用

* [sqlite-net](https://github.com/praeclarum/sqlite-net)
* [Support source code integration of sqlite3 for Unity IL2CPP](https://github.com/praeclarum/sqlite-net/pull/1104)
