# CrewChief Auto Start
CrewChief Auto Start is a simple utility program designed to automatically launch CrewChief, a popular race engineer software, along with your favorite supported racing simulations. 
It simplifies the process of starting CrewChief and launching your racing games/simulations, ensuring a smooth and hassle-free experience for users.

## Features
- Automatically starts CrewChief with the correct configuration selected when launching supported racing simulations.
- Monitors the status of the iRacing simulation and starts/stops CrewChief accordingly.
- Easy configuration through an XML file.
- Support for various racing simulations, including iRacing, Assetto Corsa, and more.

## Prerequisites
Before using CrewChief Auto Start, ensure you have the following:

- CrewChief installed on your system.
- The main executable paths for your racing simulations.

## Installation
1. Download the latest release of CrewChief Auto Start from the Releases page.
2. Extract the contents of the ZIP file to a location of your choice.
3. Optionally, create a shortcut to CrewChiefAutoStart.exe on your desktop for easy access.

## Usage
1. Open the config.xml file located in the application directory.
2. Specify the path to the CrewChief executable (<crewChiefPath>) and the details of your racing simulations (<games>).
3. Save the config.xml file.
4. Double-click CrewChiefAutoStart.exe to launch the application.
5. The application will automatically monitor the status of the iRacing simulation and start/stop CrewChief accordingly.
6. If multiple racing simulations are configured, you'll be prompted to select the simulation you want to launch.

## Configuration
The config.xml file contains the configuration settings for CrewChief Auto Start. Here's how to configure it:

- ```<crewChiefPath>```: Specify the path to the CrewChief executable.
- ```<games>```: Define the list of supported racing simulations. Each game entry should include the simulation name (<name>) and the path to its main executable (<path>).

## Example Configuration
```xml
<config>
	<crewChiefPath>C:\Program Files\CrewChiefV4\CrewChiefV4.exe</crewChiefPath>
	<games>
		<game>
			<name>iRacing</name>
			<path>D:\Games\iRacing\ui\iracingui.exe</path>
		</game>
		<game>
			<name>AssettoCorsa_64BIT</name>
			<path>D:\Games\Assetto Corsa\AC64.exe</path>
		</game>
	</games>
</config>
```

## Supported Simulators
- RaceRoom
- Project CARS 2 (PCARS2)
- Project CARS 64-bit (PCARS_64BIT)
- Project CARS 32-bit (PCARS_32BIT)
- Project CARS Network (PCARS_NETWORK)
- Project CARS 2 Network (PCARS2_NETWORK)
- rFactor 1 (RaceFactor1)
- Assetto Corsa 64-bit (AssettoCorsa_64BIT)
- Assetto Corsa 32-bit (AssettoCorsa_32BIT)
- rFactor 2 (RaceFactor2)
- rFactor 2 64-bit (RaceFactor2_64BIT)
- iRacing
- F1 2018 (F1_2018)
- F1 2019 (F1_2019)
- Assetto Corsa Competizione (ACC)
- Automobilista 2 (Automobilista2)
- Automobilista 2 Network (Automobilista2_NETWORK)
- Automobilista (Automobilista)
- Formula Truck (FTRUCK)
- MARCAS
- Game Stock Car (GameStockCar)

## Attributions
[Formula 1 icons created by Flat Icons - Flaticon](https://www.flaticon.com/free-icons/formula-1 )

## License
MIT License

Copyright (c) 2024 SoBo7a

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.