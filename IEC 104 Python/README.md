# [IEC 60870-5-104 Protocol - python windows and Linux](https://www.freyrscada.com/iec-60870-5-104-python.php)

The IEC 104 Protocol Server and Client implemetation in Phyton.

[![IEC 104 Protocol Python](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/iec104-python.jpg)](https://www.freyrscada.com/iec-60870-5-104-python.php)

we did a python wrapper for our IEC 104 implementation using ctypes, and tested in Windows and linux x86_64.

in the package tests folder , you can find the server and client test programs.

using this, you can simulate complete IEC 104 Server device(iec104servertest.py) and client(iec104clienttest.py).

or

PyPI page [https://pypi.org/project/pyiec104/](https://pypi.org/project/pyiec104/)

install using - pip install pyiec104

[Microsoft Visual C++ Redistributable X64](https://download.microsoft.com/download/1/6/5/165255E7-1014-4D0A-B094-B6A430A6BFFC/vcredist_x64.exe)
[Microsoft Visual C++ Redistributable X86](https://download.microsoft.com/download/1/6/5/165255E7-1014-4D0A-B094-B6A430A6BFFC/vcredist_x86.exe)


# [IEC 60870-5-104 Protocol](http://www.freyrscada.com/iec-60870-5-104.php)

RTU Server Simulator, Master Client Simulator, Windows and Linux POSIX ARM, IEC104 Source Code in C, C++, C# .NET Programming


[![IEC 60870-5-104 Protocol](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/iec-60870-5-104-protocol.jpg)](http://www.freyrscada.com/iec-60870-5-104.php)

Make your RTU, protocol converter, Gateway, HMI, Data concentrator compatible with iec 104.

* [IEC 60870-5-104 Source Code Windows C C++ C# .net Linux Arm POSIX C C++](#iec-60870-5-104-source-code-windows-c-c-c-net-linux-arm-posix-c-c)
* [IEC 60870-5-104 Protocol RTU IED Server Simulator](#iec-60870-5-104-rtu-ied-server-simulator)
* [IEC 60870-5 part 104 Protocol Client Master Simulator](#iec-60870-5-104-protocol-client-master-simulator)
* [IEC 104 Windows C C++ C# .NET Programming](#iec-60870-5-part-104-windows-c-c-c-net-programming)
* [IEC 60870-5 part 104 Protocol Linux Posix C C++ ARM](#iec-60870-5-104-protocol-linux-development-posix-c-c-arm)
* [IEC 60870-5 104 Protocol Video](#iec-60870-5-part-104-protocol-video-tutorial)


## [Download Evaluation Kit - IEC 104 Development Bundle](http://www.freyrscada.com/iec-60870-5-104.php#Download-IEC60870-5-104-Development-Bundle)

In the Development Bundle, We included IEC 104 Protocol Server  Client Simulator, Windows and Linux SDK, C# projects, Doxygen documentation and Raspberry Pi, BeagleBone Demo library.


# [IEC 60870-5-104 Source Code Windows C C++ C# .net Linux Arm POSIX C C++](http://www.freyrscada.com/iec-60870-5-104-Source-Code-Library.html)


The most complete implementation of IEC 104 protocol stack including File transfer (Monitor and Control Direction), Directory Commnads, Supports all type of Monitoring, command , parameter ASDUs.

Low memory footprint, easy start on any hardware platform, can operate with or without an operating system, delivered as a source code,

high configurability allows to use required features only, royalty-free licensing.


[![IEC 60870-5-104 Code Windows C C++ C# .net Linux Arm POSIX](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/IEC-60870-5-104-source-code-library-stack.jpg)](http://www.freyrscada.com/iec-60870-5-104-Source-Code-Library.html)


## Salient Features


 - Written in ANSI-Standard C Source Code, under a strict corporate coding standard, and supports C++, C#

 - Transparent licensing scheme - No hidden costs, No deferred payments.

 - High performance, robust and scalable architecture

 - Provides a simple method for systems Integrators and OEMs to utilize standard tools to implement their systems

 - Our stacks are fully compliant with "POSIX" and tested in ubuntu, feroda, Debian, QNX, Linux Embedded OS and Various Cross compiler tool chains.

 - Our all protocol stack supports "POSIX compliant operating system"

 - Context-based event-driven model

 - Multiple Server and Client Simulation

 - In a Single Server(link) simulate Multiple Stations (Common Address / Station Address)

 - Supports Background Scan, Cyclic Data Transmission, Double Transmission, Redundancy and File transfer.

 - Communication with redundant control systems and interruption-free switch over between redundant systems

 - Supports "Select-Before-Operate" and "Direct-Execute" command execution modes

 - In IEC 60870-5-104 Client Side, Data Mode and Test mode connection type available.

 - Source Code Library allows a fast and cost efficient implementation

 - APIs are designed to be very easy to use and flexible


## Knowledge Base - Interoperability

[IEC 60870-5-104 Protocol Server Interoperability](http://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Server-Interoperability.pdf)

[IEC 60870-5-104 protocol Client Interoperability](http://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Client-Interoperability.pdf)
 


# [IEC 60870-5-104 RTU IED Server Simulator](http://www.freyrscada.com/iec-60870-5-104-Server-Simulator.php)


Complete Simulation of IEC 104 Server as per Protocol Standard including File transfer (Both Monitoring and control direction).

[![IEC 60870-5-104 Protocol RTU IED Server Simulator](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/iec104-server-sim.jpg)](http://www.freyrscada.com/iec-60870-5-104-Server-Simulator.php)


​Support all type of ASDU Typeid according to protocol specification

1) Monitoring (Process information in monitor direction), M_SP. M_DP, M_ST,...

2) control (Process information in control direction), C_SC, C_DC, ...

3) System information in monitor direction, M_EI

4) System information in control direction C_IC, C_CI

5) Parameter in control direction, P_ME

6) File transfer ( Both Monitor And Control Direction) F_FR, F_SR, F_SC



IEC 104 Server Simulator developed to test the functionalities of IEC 60870-5-104 stack Source code Library - server Operation.

We can add up to 50 server node in the simulator. Every server node will work independently.

Simulator window shows the status & connection ip address, port number, redundancy enabled or not, If Redundancy enabled it shows, the redundant source ip address, port .

The user can update the monitoring Point information. The following parameters can change Value and quality bits.


## Features


 - Multiple Server Simulation

 - In a Single Server(link) simulate Multiple Stations (Common Address)

 - Redundancy Enabled

 - Mapping of Control Point to monitor Information point, consider C_SC point can map to M_SP point

 - Communication with redundant control systems and interruption-free switchover between redundant systems

 - Supports "select-before-operate" or "direct-execute" command execution modes

 - supports File Transfer ( Both Monitor And Control Direction), Directory commands

 - Clock synchronization, General Interrogation, counter interrogation,

 - Parameter command

 - On-demand transmission (e. g. single indications, analogs...)

 - Spontaneous transmission (e. g. single indications with time tag ...)


## [IEC 60870-5-104 Protocol RTU Server Simulator User Manual](http://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Server-Simulator-User-Manual.pdf)



# [IEC 60870-5-104 Protocol Client Master Simulator](http://www.freyrscada.com/iec-60870-5-104-Client-Simulator.php)


Complete Simulation of IEC 104 Client as per Protocol Standard including File transfer (Both Monitoring and control direction).

[![IEC 60870-5 part 104 Protocol Client Master Simulator](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/iec104-client-sim.jpg)](http://www.freyrscada.com/iec-60870-5-104-Client-Simulator.php)


​Support all type of ASDU Typeid according to protocol specification

1) Monitoring (Process information in monitor direction), M_SP. M_DP, M_ST,...

2) control (Process information in control direction), C_SC, C_DC, ...

3)  System information in monitor direction, M_EI

4) System information in control direction C_IC, C_CI

5)  Parameter in control direction, P_ME

6) File transfer ( Both Monitor And Control Direction) F_FR, F_SR, F_SC


IEC 104 Client Simulator was originally developed to test the functionalities of IEC 60870-5-104 stack Client operation.

We can add up to 50 Client node in the simulator. Every Client node will work independently.

Simulator window shows the Connection status, connection ip address and port number.


## Features

 - Multiple Master / Client Simulation

 - In a Single Client(link) simulate Multiple Stations (Common Address)

 - Data Mode, and Test mode connection type available

 - Supports "Select-Before-Operate" SBO or "Direct-execute" command execution modes

 - supports File Transfer ( Both Monitor And Control Direction), Directory commands

 - Clock synchronization, General Interrogation, counter interrogation, 

 - Parameter command


## [IEC 60870-5-104 Protocol Client Master Simulator User Manual](http://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Client-Simulator-User-Manual.pdf)



# [IEC 60870-5 part 104 Windows C C++ C# .NET Programming](http://www.freyrscada.com/iec-60870-5-104-Windows-Software-Development-Kit(SDK).php)


IEC 60870-5-104 Demo Win DLL includes simple (Server & Client C programs, c# .net )example using a Command window and command line inputs.

The source code will allow you to quickly compile your own examples with the features of your existing development environment to work with our IEC 60870-5-104 DLL..IEC 104 Windows SDK contains Win DLL (precompiled library), Static link lib, Demo IEC104 Server & Client programs, Visual Studio Demo console project files, Doxygen .

We used Visual studio compiler to create the dll, sample test projects.


[![IEC 60870-5-104 Windows C C++ C# .NET](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/iec-104-windows-protocol.jpg)](http://www.freyrscada.com/iec-60870-5-104-Windows-Software-Development-Kit(SDK).php)


This evaluation package allows you to:

Access product manual(API documentation)(pdf, Doxygen html)

Browse the IEC 60870-5-104 library API documentation

Study the source code of the IEC 60870-5-104 examples provided

Modify and compile the IEC 60870-5-104 examples

Create your own IEC 60870-5-104 programs and test with leading test tools

You can use the source code of the application examples and modify them according to your needs.


# [IEC 60870-5-104 Protocol Linux Development POSIX C C++ ARM](http://www.freyrscada.com/iec-60870-5-104-Linux-Software-Development-Kit(SDK).php)


IEC 104 Demo Linux Shared Library includes simple (Server & Client C programs )example using a Command window and command line inputs.

The source code will allow you to quickly compile your own examples with the features of your existing development environment to work with our IEC 60870-5-104 library.

IEC 60870-5-104 Linux SDK contains Shared Library(.a) (precompiled library), Static link lib, Demo IEC104 Server & Client programs, CodeBlock Demo console project files, Doxygen .

We used gcc compiler to create the Shared Library, sample test projects.

[![IEC 60870-5-104 Protocol Linux C C++ POSIX](https://github.com/FreyrSCADA/IEC-60870-5-104/raw/master/img/iec-104-linux-protocol.jpg)](http://www.freyrscada.com/iec-60870-5-104-Linux-Software-Development-Kit(SDK).php)


This evaluation package allows you to:

 - Access product manual(API documentation)(pdf, Doxygen html)

 - Browse the IEC 60870-5-104 library API documentation

 - Study the source code of the IEC 60870-5-104 examples provided

 - Modify and compile the IEC 60870-5-104 examples

 - Create your own IEC 60870-5-104 programs and test with leading test tools

 - You can use the source code of the application examples and modify them according to your needs.


Minimum system requirements

Supports Embedded Linux (ARM, Coldfire, Power PC), Ubuntu Linux(X86, X86-64), Fedora, CentOS, Red Hat...(All Posix Compliant Operating Systems)

gcc - Any IDE supports C & C++ Programming, support all your cross tool chain




# [IEC 60870-5 part 104 Protocol Video Tutorial](https://www.youtube.com/playlist?list=PL4tVfIsUhy1bx7TVjtZnqFB6tbZBhOlJP)

## [IEC 60870-5-104 Protocol Product Description Video](http://www.freyrscada.com/iec-60870-5-104-video.html)	
[![IEC 60870-5-104 Protocol Product Description Video](http://www.freyrscada.com/images/iec104videoicon.jpg)](http://www.freyrscada.com/iec-60870-5-104-video.html)

## [IEC 60870-5-104 Protocol Server Simulator test with third party tool](http://www.freyrscada.com/IEC104_Server_Simulator_Testing.html)	
[![IEC 60870-5-104 Protocol Server Simulator test with third party tool](http://www.freyrscada.com/images/iec104-server-simulator-testing.jpg)](http://www.freyrscada.com/IEC104_Server_Simulator_Testing.html)

## [IEC 60870-5-104 Protocol Client Master Simulator test with third party tool](http://www.freyrscada.com/IEC104_Client_Simulator_Testing.html)	
[![IEC 60870-5-104 Protocol Client Master Simulator test with third party tool](http://www.freyrscada.com/images/iec104-client-simulator-testing.jpg)](http://www.freyrscada.com/IEC104_Client_Simulator_Testing.html)

## [IEC 60870-5-104 Protocol Server and Client Simulator - File Transfer, Directory command operation](http://www.freyrscada.com/IEC-60870-5-104-Server-Client-File-Transfer-video.html)	
[![IEC 60870-5-104 Protocol Server and Client Simulator - File Transfer, Directory command operation](http://www.freyrscada.com/images/iec104videoiconfiletransfer.jpg)](http://www.freyrscada.com/IEC-60870-5-104-Server-Client-File-Transfer-video.html)

## [IEC 60870-5-104 Protocol Server Simulator with Kepware OPC](http://www.freyrscada.com/IEC104_Server_Simulator_Kepware_OPC.html)	
[![IEC 60870-5-104 Protocol Server Simulator with Kepware OPC](http://www.freyrscada.com/images/IEC104_Server_Simulator_Kepware_OPC.jpg)](http://www.freyrscada.com/IEC104_Server_Simulator_Kepware_OPC.html)

## [IEC 60870-5-104 Protocol File transfer - Control Direction](http://www.freyrscada.com/IEC104-Filetransfer-controldirection.html)	
[![IEC 60870-5-104 Protocol File transfer - Control Direction](http://www.freyrscada.com/images/iec104-filetransfer-controldirection.jpg)](http://www.freyrscada.com/IEC104-Filetransfer-controldirection.html)

## [IEC 60870-5-104 Protocol Server Simulator With Reliance HMI SCADA](http://www.freyrscada.com/IEC104_Server_Simulator_Reliance-HMI-SCADA.html)	
[![IEC 60870-5-104 Protocol Server Simulator With Reliance HMI SCADA](http://www.freyrscada.com/images/IEC104_Server_Simulator_Reliance-HMI-SCADA.jpg)](http://www.freyrscada.com/IEC104_Server_Simulator_Reliance-HMI-SCADA.html)

## [IEC 60870-5-104 Protocol Server in Beaglebone Arm Linux](http://www.freyrscada.com/IEC104_Server_Beaglebone_Arm_Linux.html)	
[![IEC 60870-5-104 Protocol Server in Beaglebone Arm Linux](http://www.freyrscada.com/images/IEC104_Server_Beaglebone_Arm_Linux.jpg)](http://www.freyrscada.com/IEC104_Server_Beaglebone_Arm_Linux.html)

## [IEC 60870-5-104 Protocol Server Redundancy](http://www.freyrscada.com/iec-104-redundancy.html)	
[![IEC 60870-5-104 Protocol Server Redundancy](http://www.freyrscada.com/images/iec-104-redundancy.jpg)](http://www.freyrscada.com/iec-104-redundancy.html)

## [IEC 60870-5-104 Protocol Server Simulator With VTScada HMI SCADA](http://www.freyrscada.com/IEC104-Server-Simulator-With-VTScada.html)	
[![IEC 60870-5-104 Protocol Server Simulator With VTScada HMI SCADA](http://www.freyrscada.com/images/IEC104-Server-Simulator-With-VTScada.jpg)](http://www.freyrscada.com/IEC104-Server-Simulator-With-VTScada.html)

## [IEC 60870-5-104 Protocol Server Simulator With Matrikon OPC](http://www.freyrscada.com/IEC104-Server-Simulator-With-Matrikon-OPC.html)	
[![IEC 60870-5-104 Protocol Server Simulator With Matrikon OPC](http://www.freyrscada.com/images/iec104-matrikon-opcwithsub.JPG)](http://www.freyrscada.com/IEC104-Server-Simulator-With-Matrikon-OPC.html)

## [ClearSCADA IEC 60870-5-104 Protocol IED Server Simulator testing](http://www.freyrscada.com/clearscada-iec104-point-command-simulation.html)	
[![ClearSCADA IEC 60870-5-104 Protocol IED Server Simulator testing](http://www.freyrscada.com/images/clearscadaiec104.jpg)](http://www.freyrscada.com/clearscada-iec104-point-command-simulation.html)

## [ClearSCADA IEC 60870-5-104 Protocol Server Simulator download upload file transfer directory view](http://www.freyrscada.com/clearscada-iec104-file-transfer.html)	
[![ClearSCADA IEC 60870-5-104 Protocol Server Simulator download upload file transfer directory view](http://www.freyrscada.com/images/clearscada-iec104-filetransfer.jpg)](http://www.freyrscada.com/clearscada-iec104-file-transfer.html)


[facebook](https://www.facebook.com/IEC104/)

[linkedin](https://in.linkedin.com/showcase/iec-60870-5-104)  

[youtube](https://www.youtube.com/playlist?list=PL4tVfIsUhy1bx7TVjtZnqFB6tbZBhOlJP)


# [Download Evaluation Kit - IEC 104 Protocol Development Bundle](http://www.freyrscada.com/iec-60870-5-104.php#Download-IEC60870-5-104-Development-Bundle)

In the Development Bundle, We included IEC 60870-5 part 104 Protocol Server  Client Simulator, Windows and Linux SDK, C# projects, Doxygen documentation and Raspberry Pi, BeagleBone Demo library.
