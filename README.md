# On-Train Entertainment (OTE)

### Installation Requirement
#### System Requirement
This application is tested and supported on Windows 10 Machine, other platform support is unknown
#### Installation steps
1. Installing windows, choose user name as "VIA RAIL", please keep capitalization and space please.
2. In the system, create the following folder and files, please keep txt file empty:
C:\Users\VIA RAIL\Desktop\log.txt
C:\Users\VIA RAIL\Desktop\test.txt
C:\Users\VIA RAIL\Desktop\station.txt
C:\Users\VIA RAIL\Desktop\Videos\
C:\Users\VIA RAIL\Desktop\Videos\kids\
C:\Users\VIA RAIL\Desktop\Videos\station\fr\
C:\Users\VIA RAIL\Desktop\Videos\station\en\
C:\Users\VIA RAIL\Desktop\Videos\seville\en\
C:\Users\VIA RAIL\Desktop\Videos\seville\fr\
C:\Users\VIA RAIL\Desktop\Videos\tv\
3. Copy and paste the full build from \debug folder to the c:\
4. Follow the steps below to disable VAC (Vital to stop windows from giving prompt)

Step 1: Click the Action Center tray icon, and choose to Open Action Center.

Step 2: Click to Change User Account Control settings to bring up the menu.

Step 3: Move the slider one position down to still be notified, but also have access to the rest of the desktop.

Step 4: Move the slider two positions down from its default location to take full responsibility for your actions.

5. Open task scheduler, set c:\debug\WindowsFormsApp1.exe start when user login
### Video Content Naming convention
#### General Film (No meta data)
Put them under C:\Users\VIA RAIL\Desktop\Videos\
filename should be nameoffilm_langugage(EN/FR) for both movie and flyer
#### Entertainment One Film (With meta data)
Put them under C:\Users\VIA RAIL\Desktop\Videos\seville\(en/fr)
use xml file sample;
```xml
<rss version = "2.0">
<item>
<title>
A Dangerous Method
</title>
<link>
a_dangerous_method.mp4
</link>
<description>
On the eve of World War I, Zurich and Vienna are the setting for a dark tale of sexual and intellectual discovery. Drawn from true-life events, A DANGEROUS METHOD takes a glimpse into the turbulent relationships between fledgling psychiatrist Carl Jung, his mentor Sigmund Freud and Sabina Spielrein, the troubled but beautiful young woman who comes between them. Into the mix comes Otto Gross, a debauched patient who is determined to push the boundaries. In this exploration of sensuality, ambition and deceit set the scene for the pivotal moment when Jung, Freud and Sabina come together and split apart, forever changing the face of modern thought.
</description>
<pubDate>
3/27/2012
</pubDate>
<category>
14A
</category>
</item>
</rss>
```

#### TV programmes or kids programmes (With meta data)

Put them under C:\Users\VIA RAIL\Desktop\Videos\tv\title_of_series
use xml file sample;

```xml
<rss version = "2.0">
    <item>
        <title>This Hour Has 22 Minutes</title>
        <link>cbc_22_minutes_season_24_s24e01_via.mp4</link>
        <description>National Defence Minister Harjit Sajjan guest stars when This Hour Has 22 Minutes returns for its 24th season. Also featuring a field report from the most-watched U.S. presidential debate ever.</description>
        <pubDate>2016-10-04</pubDate>
        <category>PG</category>
    </item>
</rss>
```

#### Station Information (With meta data)

Put them under C:\Users\VIA RAIL\Desktop\Videos\station\(en/fr)\name_of_station
put a picture of station
use xml file sample;

```xml
<item>
<title>
Moncton train station
</title>
<location>
1240 Main Street
Moncton, NB, E1C 0E6, Canada 
</location>
<contact>
Arrivals and departures: (506) 857-9830
Information and reservation: (506) 857-9830
</contact>
<description>
Ticket Counter:
Monday Thursday Friday Saturday Sunday
10h30 to 18h15
Wednesday
14h30 to 18h15
Station closed on Tuesday.

Station:
Monday Thursday Friday Saturday Sunday
10h30 to 18h15
Wednesday
14h30 to 18h15
Baggage
Monday Thursday Friday Saturday Sunday
10h30 to 18h15
Wednesday
14h30 to 18h15
</description>
<parking>
Long and Short term: Limited, outdoor and free.
For long-term parking (more than 7 days), customers should absolutely notify the station staff for availability and instructions on where to park.
</parking>
<public>
Codiac Transit 506 857-2008 (city)
Maritime Bus 800 575-1807
</public>
</item>
```
