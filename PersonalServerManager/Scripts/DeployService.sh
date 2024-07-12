#!/bin/bash

# Navigate to the directory containing the folder you want to zip
cd /mnt/c/My/Workdir/Deploy/Name

# Use the zip command to create a zip archive
zip -j -r Name.zip /mnt/c/My/Workdir/Deploy


# Clean folders
sshpass -p 'pwd' ssh root@ip 'rm -r /opt/Name'

# Create folder on remote host
sshpass -p 'pwd' ssh root@1ip 'mkdir /opt/Name'

# Create folder on remote host
sshpass -p 'pwd' ssh root@ip 'mkdir /opt/Name/bin'

# Upload
pscp -pw pwd /mnt/c/My/Workdir/Deploy/Name.zip root@1ip:/opt/Name

# Unzip
sshpass -p 'pwd' ssh root@ip 'mkdir /opt/Name/bin'
sshpass -p 'pwd' ssh root@ip 'unzip /opt/Name/Name.zip -d /opt/Name/bin'

# Copy service file
pscp -pw pwd /mnt/c/My/Workdir/Name.service root@ip:/etc/systemd/system