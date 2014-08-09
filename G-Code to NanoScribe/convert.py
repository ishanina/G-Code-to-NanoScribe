#-------------------------------------------------------------------------------
# Name:        Main
# Purpose:     This takes a G-Code file, and converts it to work with the
#              Nanoscribe
#
# Author:      Ishan Levy
#
# Created:     05/08/2014
# Copyright:   (c) Ishan 2014
# Licence:     Creative Commons (CC)
#-------------------------------------------------------------------------------

import sys

# Takes a line of input and returns the part that is a comment
def getComment(line):
    return line[line.find(";")+2:-1]


# Takes a line of input and returns the part that is a command
def getCommand(line):
    return line[:line.find(";")]


# Takes a command and returns the value corresponding to a particular axis
def getAxis(axisname,string,current):
    if string.find(axisname) != -1:
        return float(string[string.find(axisname)+1:string.find(" ",string.find(axisname)+1)])
    else:
    # If the axis is not found, the original value is returned
        return current


# Takes values for axes, and prints them out along with their comment
def writeAxes(x,y,z,comment,file):
    file.write(str(x) + " " + str(y) + " " + str(z) + " " + comment + "\n")


# Takes array of perimeters, and prints one
def printCoords(x,y,z,i):
    for j in xrange(len(x[i])):
        printAxes(x[i][j],y[i][j],z[i][j],"")




def main():
    #print sys.argv
    filename = sys.argv[1]
    outfilename = sys.argv[2]
    skipLayers = int(sys.argv[3]) + 1
    #print skipLayers
    file = open(filename)
    outfile = open(outfilename,"w")
    # Starting Values for x, y, and z
    xAxis = 0
    yAxis = 0
    zAxis = 0
    firstX = 0
    firstY = 0
    firstZ = 0
    perimeterGoing = False
    fillGoing = False
    extruding = False
    for rawline in file:
        comment = getComment(rawline)
        command = getCommand(rawline)
        extrude = command.find(" E")
        oldZAxis = zAxis
        if comment.startswith("move to next layer"):
            zAxis = getAxis("Z",command,zAxis)
            if oldZAxis == 0:
                zStep = zAxis
                #print zStep
            #sys.stdout.write('.')
        if command.startswith("G1"):
            xAxis = getAxis("X",command,xAxis)
            yAxis = getAxis("Y",command,yAxis)
            if extrude == -1 and extruding:
                if (int(round(zAxis/zStep)) - 1) % skipLayers == 0:
                    writeAxes(firstX,firstY,firstZ,"",outfile)
                    outfile.write("Write\n") #Pseudo G-Code
                extruding = False
            elif extrude != -1 and extruding == False:
                firstX = getAxis("X",command,firstX)
                firstY = getAxis("Y",command,firstY)
                firstZ = zAxis
                #outfile.write("Write\n") #Pseudo G-Code
                extruding = True
            #print str((int(round(zAxis/zStep)) - 1) % skipLayers) + " " + str(zAxis)
            if extruding and (int(round(zAxis/zStep)) - 1) % skipLayers == 0:
                writeAxes(xAxis,yAxis,zAxis,"",outfile)
            #writeAxes(xAxis,yAxis,zAxis,"% " + comment,outfile)
    outfile.close()


if __name__ == '__main__':
    main()