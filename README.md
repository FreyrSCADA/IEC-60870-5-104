# [IEC 60870-5-104 Protocol](https://www.freyrscada.com/iec-60870-5-104.php)

RTU Server Simulator, Master Client Simulator, Windows and Linux (ARM), Source Code in C, C++, C# .NET Programming

IEC 60870-5-104 enables communication between IED, RTU control station and substation via a standard TCP/IP network. 
The TCP protocol is used for connection-oriented secure data transmission.
IEC 60870-5-104 protocol (IEC 104) is a part of IEC Telecontrol Equipment and Systems Standard IEC 60870-5 that provides a communication profile for sending basic telecontrol messages between two systems in electrical engineering and power system automation.
IEC 60870 part 5 is one of the IEC 60870 set of standards which define systems used for telecontrol (supervisory control and data acquisition SCADA) in electrical engineering and power system automation applications. 
Part 5 provides a communication profile for sending basic telecontrol messages between two systems, which uses permanent directly connected data circuits between the systems. The IEC Technical Committee 57 (Working Group 03) have developed a protocol standard for telecontrol, teleprotection, and associated telecommunications for electric power systems. 
The result of this work is IEC 60870-5. Five documents specify the base IEC 60870-5:

- IEC 60870-5-1 Transmission Frame Formats
- IEC 60870-5-2 Data Link Transmission Services
- IEC 60870-5-3 General Structure of Application Data
- IEC 60870-5-4 Definition and Coding of Information Elements
- IEC 60870-5-5 Basic Application Functions

![IEC 60870-5-104 Protocol](https://www.freyrscada.com/images/104w320x220.jpg)

Make your RTU, protocol converter, Gateway, HMI, Data concentrator compatible with iec 104.

* [IEC 60870-5-104 Source Code Windows C C++ C# .net Linux Arm POSIX C C++](#iec-60870-5-104-source-code-windows-c-c-c-net-linux-arm-posix-c-c)
* [IEC 60870-5-104 Protocol RTU IED Server Simulator](#iec-60870-5-104-rtu-server-simulator)
* [IEC 60870-5 part 104 Protocol Client Master Simulator](#iec-60870-5-104-protocol-client-master-simulator)
* [IEC 104 Windows C C++ C# .NET Programming](#iec-60870-5-part-104-windows-c-c-c-net-programming)
* [IEC 60870-5 part 104 Protocol Linux Posix C C++ ARM](#iec-60870-5-104-protocol-linux-development-posix-c-c-arm)
* [IEC 60870-5 104 Protocol Video](#iec-60870-5-part-104-protocol-video-tutorial)


[Download Evaluation Kit - IEC 104 Development Bundle](https://www.freyrscada.com/iec-60870-5-104.php#Download-IEC60870-5-104-Development-Bundle)

In the Development Bundle, We included IEC 104 Protocol Server  Client Simulator, Windows and Linux SDK, C# projects, Doxygen documentation and Raspberry Pi, BeagleBone Demo library.


# [IEC 60870-5-104 Source Code Windows C C++ C# .net Linux Arm POSIX C C++](https://www.freyrscada.com/iec-60870-5-104-Source-Code-Library.html)


The most complete implementation of IEC 104 protocol stack including File transfer (Monitor and Control Direction), Directory Commnads, Supports all type of Monitoring, command , parameter ASDUs.

Low memory footprint, easy start on any hardware platform, can operate with or without an operating system, delivered as a source code,

high configurability allows to use required features only, royalty-free licensing.


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



## Application Examples

 - Integrate existing devices to a modern control system with a field proven product

 - Use the IEC-104 event based communication instead of polling

 - Feeder automation

 - Substation automation

 - Utility automation

 - Reclosers

 - Protection relays
 
  
## Standard IEC 60870-5-104 ASDU - Typeids


Type            Dec             Description


M_SP_NA_1         1         Single-point information

M_SP_TA_1         2         Single-point information with time tag  ( IEC 101 Supported )

M_DP_NA_1         3         Double-point information

M_DP_TA_1         4         Double-point information with time tag ( IEC 101 Supported )

M_ST_NA_1         5         Step position information

M_ST_TA_1         6         Step position information with time tag ( IEC 101 Supported )

M_BO_NA_1         7         Bitstring of 32 bit

M_BO_TA_1         8         Bitstring of 32 bit with time tag ( IEC 101 Supported )

M_ME_NA_1         9         Measured value, normalised value

M_ME_TA_1         10        Measured value, normalized value with time tag ( IEC 101 Supported )

M_ME_NB_1         11        Measured value, scaled value

M_ME_TB_1         12        Measured value, scaled value wit time tag ( IEC 101 Supported )

M_ME_NC_1         13        Measured value, short floating point number

M_ME_TC_1         14        Measured value, short floating point number with time tag ( IEC 101 Supported )

M_IT_NA_1         15        Integrated totals

M_IT_TA_1         16        Integrated totals with time tag ( IEC 101 Supported )

M_EP_TA_1         17        Event of protection equipment with time tag

M_EP_TB_1         18        Packed start events of protection equipment with time tag

M_EP_TC_1         19        Packed output circuit information of protection equipment with time tag

M_PS_NA_1         20        Packed single point information with status change detection

M_ME_ND_1         21        Measured value, normalized value without quality descriptor

ASDU_TYPE_22..29  22..29    Reserved (standard area)

M_SP_TB_1         30        Single-point information with time tag CP56Time2a

M_DP_TB_1         31        Double-point information with time tag CP56Time2a

M_ST_TB_1         32        Step position information with time tag CP56Time2a

M_BO_TB_1         33        Bitstring of 32 bit with time tag CP56Time2a

M_ME_TD_1         34        Measured value, normalised value with time tag CP56Time2a

M_ME_TE_1         35        Measured value, scaled value with time tag CP56Time2a

M_ME_TF_1         36        Measured value, short floating point number with time tag CP56Time2a

M_IT_TB_1         37        Integrated totals with time tag CP56Time2a

M_EP_TD_1         38        Event of protection equipment with time tag CP56Time2a

M_EP_TE_1         39        Packed start events of protection equipment with time tag CP56Time2a

M_EP_TF_1         40        Packed output circuit information of protection equipment with time tag CP56Time2a

ASDU_TYPE_41..44  41..44    Reserved (standard area)

C_SC_NA_1         45        Single command

C_DC_NA_1         46        Double command

C_RC_NA_1         47        Regulating step command

C_SE_NA_1         48        Set-point Command, normalized value

C_SE_NB_1         49        Set-point Command, scaled value

C_SE_NC_1         50        Set-point Command, short floating point number

C_BO_NA_1         51        Bitstring 32 bit command

ASDU_TYPE_52..57  52..57    Reserved (standard area)

C_SC_TA_1         58        Single command with time tag CP56Time2a

C_DC_TA_1         59        Double command with time tag CP56Time2a

C_RC_TA_1         60        Regulating step command with time tag CP56Time2a

C_SE_TA_1         61        Measured value, normalised value command with time tag CP56Time2a

C_SE_TB_1         62        Measured value, scaled value command with time tag CP56Time2a

C_SE_TC_1         63        Measured value, short floating point number command with time tag CP56Time2a

C_BO_TA_1         64        Bitstring of 32 bit command with time tag CP56Time2a

ASDU_TYPE_65..69  65..69    Reserved (standard area)

M_EI_NA_1         70        End of Initialization

ASDU_TYPE_71..99  71..99    Reserved (standard area)

C_IC_NA_1         100       Interrogation command

C_CI_NA_1         101       Counter interrogation command

C_RD_NA_1         102       Read command

C_CS_NA_1         103       Clock synchronization command

C_TS_NA_1         104       Test command

C_RP_NA_1         105       Reset process command

C_CD_NA_1         106       Delay acquisition command

C_TS_TA_1         107       Test command with time tag CP56Time2a

ASDU_TYPE_108..109 108..109 Reserved (standard area)

P_ME_NA_1         110       Parameter of measured values, normalized value

P_ME_NB_1         111       Parameter of measured values, scaled value

P_ME_NC_1         112       Parameter of measured values, short floating point number

P_AC_NA_1         113       Parameter activation

ASDU_TYPE_114..119 114..119 Reserved (standard area)

F_FR_NA_1         120      File ready

F_SR_NA_1         121      Section ready

F_SC_NA_1         122      Call directory, select file, call file, call section

F_LS_NA_1         123      Last section, last segment

F_FA_NA_1         124      ACK file, ACK section

F_SG_NA_1         125      Segment

F_DR_TA_1         126      Directory

ASDU_TYPE_127..255  127..255  Reserved (user area)



## Knowledge Base - Interoperability



[IEC 60870-5-104 Protocol Server Interoperability](https://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Server-Interoperability.pdf)


[IEC 60870-5-104 protocol Client Interoperability](https://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Client-Interoperability.pdf)

 

## Licensing


### [Source Code License model:](https://www.freyrscada.com/iec-60870-5-104-Source-Code-Library.html)

In this License model, We deliver complete source code of the protocol implementation according to the customer specified operating system(Windows, Linux, QNX...).

Customer may embed the library into unlimited copies of Multiple end-use products for worldwide manufacturing, branding and distribution. Original equipment manufacturers choose this model. They usually have multiple products in their pipeline.



### Compiled Library License model:


In this License model, We deliver Dynamic/ Static compiled library (dll / lib) of the protocol implementation according to the customer specified operating system(Windows, Linux, QNX...).

Customer may embed the library into unlimited copies of Multiple end-use products for worldwide manufacturing, branding and distribution. Original equipment manufacturers choose this model. They usually have multiple products in their pipeline.


### Simulator License model: (Annual subscription based)

In this License model, We deliver Simulator Installer for Windows Operating System.

The Customer can use the software company wide. Customer can install the software in many systems.

There is no restriction like Hardware key (Dongle) and software key.



# [IEC 60870-5-104 RTU Server Simulator](https://www.freyrscada.com/iec-60870-5-104-Server-Simulator.php)


Complete Simulation of IEC 104 Server as per Protocol Standard including File transfer (Both Monitoring and control direction).


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


Features


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



[IEC 60870-5-104 Protocol RTU Server Simulator User Manual](https://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Server-Simulator-User-Manual.pdf)


# [IEC 60870-5-104 Protocol Client Master Simulator](https://www.freyrscada.com/iec-60870-5-104-Client-Simulator.php)


Complete Simulation of IEC 104 Client as per Protocol Standard including File transfer (Both Monitoring and control direction).


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


Features


 - Multiple Master / Client Simulation

 - In a Single Client(link) simulate Multiple Stations (Common Address)

 - Data Mode, and Test mode connection type available

 - Supports "Select-Before-Operate" SBO or "Direct-execute" command execution modes

 - supports File Transfer ( Both Monitor And Control Direction), Directory commands

 - Clock synchronization, General Interrogation, counter interrogation, 

 - Parameter command



[IEC 60870-5-104 Protocol Client Master Simulator User Manual](https://www.freyrscada.com/docs/FreyrSCADA-IEC-60870-5-104-Client-Simulator-User-Manual.pdf)



# [IEC 60870-5 part 104 Windows C C++ C# .NET Programming](https://www.freyrscada.com/iec-60870-5-104-Windows-Software-Development-Kit(SDK).php)


IEC 60870-5-104 Demo Win DLL includes simple (Server & Client C programs, c# .net )example using a Command window and command line inputs.

The source code will allow you to quickly compile your own examples with the features of your existing development environment to work with our IEC 60870-5-104 DLL..IEC 104 Windows SDK contains Win DLL (precompiled library), Static link lib, Demo IEC104 Server & Client programs, Visual Studio Demo console project files, Doxygen .


We used Visual studio compiler to create the dll, sample test projects.


This evaluation package allows you to:

Access product manual(API documentation)(pdf, Doxygen html)

Browse the IEC 60870-5-104 library API documentation

Study the source code of the IEC 60870-5-104 examples provided

Modify and compile the IEC 60870-5-104 examples

Create your own IEC 60870-5-104 programs and test with leading test tools

You can use the source code of the application examples and modify them according to your needs.



# [IEC 60870-5-104 Protocol Linux Development POSIX C C++ ARM](https://www.freyrscada.com/iec-60870-5-104-Linux-Software-Development-Kit(SDK).php)


IEC 104 Demo Linux Shared Library includes simple (Server & Client C programs )example using a Command window and command line inputs.

The source code will allow you to quickly compile your own examples with the features of your existing development environment to work with our IEC 60870-5-104 library.

IEC 60870-5-104 Linux SDK contains Shared Library(.a) (precompiled library), Static link lib, Demo IEC104 Server & Client programs, CodeBlock Demo console project files, Doxygen .

We used gcc compiler to create the Shared Library, sample test projects.



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



[facebook](https://www.facebook.com/IEC104/)

[linkedin](https://in.linkedin.com/showcase/iec-60870-5-104)  

[youtube](https://www.youtube.com/playlist?list=PL4tVfIsUhy1bx7TVjtZnqFB6tbZBhOlJP)


# [Download Evaluation Kit - IEC 104 Protocol Development Bundle](https://www.freyrscada.com/iec-60870-5-104.php#Download-IEC60870-5-104-Development-Bundle)

In the Development Bundle, We included IEC 60870-5 part 104 Protocol Server  Client Simulator, Windows and Linux SDK, C# projects, Doxygen documentation and Raspberry Pi, BeagleBone Demo library.
