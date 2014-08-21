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

# Note: it is possible to reduce to 3 scans
import copy
import sys
import math
import thread
import os

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


# Scans through file and returns its range
def getMinsMaxs(filename):
    sys.stdout.write("Searching through File: ")
    file = open(filename)
    xMin = 10000000
    yMin = 10000000
    zMin = 10000000
    xMax = -10000000
    yMax = -10000000
    zMax = -10000000

    for line in file:
        command = getCommand(line)
        if command.startswith("G1"):
            xMin = min(xMin,getAxis("X",command,xMin))
            yMin = min(yMin,getAxis("Y",command,yMin))
            zMin = min(zMin,getAxis("Z",command,zMin))

            xMax = max(xMax,getAxis("X",command,xMax))
            yMax = max(yMax,getAxis("Y",command,yMax))
            if getAxis("Z", command, zMax) > zMax:
                sys.stdout.write(".")
            zMax = max(zMax,getAxis("Z",command,zMax))
    print ""
    return [xMin-.00001,yMin-.00001,zMin-.00001,xMax+.00001,yMax+.00001,zMax+.00001]

# Scans through file and adds first points
def addingfirsts(filename):
    sys.stdout.write("Adding Extra Points: ")
    file = open(filename)
    if not os.path.exists(sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\"):
        os.makedirs(sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\")
    outfile = open(sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\Input.modify","w")
    xAxis = 0
    yAxis = 0
    zAxis = 0
    prevX = 0
    prevY = 0
    extruding = False
    for line in file:
        command = getCommand(line)
        comment = getComment(line)
        extrude = command.find(" E")
        rightLine = not comment.startswith("move inwards before travel") and not comment.startswith("move to first fill point") and not comment.startswith("fill")
        if command.startswith("G1") and rightLine:
            prevX = xAxis
            prevY = yAxis
            xAxis = getAxis("X",command,xAxis)
            yAxis = getAxis("Y",command,yAxis)
            if getAxis("Z", command, zAxis) > zAxis:
                sys.stdout.write(".")
                zAxis = getAxis("Z",command,zAxis)
            if extrude == -1 and extruding:
                outfile.write("G1 X" + str(firstX) + " Y" + str(firstY) + " E1 ; perimeter first point\n")
                extruding = False
            elif extrude != -1 and extruding == False:
                firstX = xAxis
                firstY = yAxis
                firstZ = zAxis
                extruding = True
        if rightLine:
            outfile.write(line)
    print ""

# Scans through file and interpolates points
def interpolatingPoints(startingX,startingY,startingZ,endingX,endingY,endingZ,stepX,stepY,stepZ,shiftX,shiftY):
    sys.stdout.write("Interpolating Points: ")
    file = open(sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\Input.modify")
    outfile = open(sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\Input.modif","w")
    xAxis = 0
    yAxis = 0
    zAxis = 0
    prevX = 0
    prevY = 0
    amountX = int(math.ceil((endingX - startingX)/stepX) + 1)
    amountY = int(math.ceil((endingY - startingY)/stepY) + 1)
    amountZ = int(math.ceil((endingZ - startingZ)/stepZ))
    startX = [startingX + stepX*i for i in xrange(amountX)]
    startY = [startingY + stepY*i for i in xrange(amountY)]
    startZ = [startingZ + stepZ*i for i in xrange(amountZ)]
    i = -1
    j = -1
    k = int(math.floor((zAxis - startingZ)/stepZ))
    oldk = 0
    numInterpolated = 10
    oldi = 0
    oldj = 0
    for line in file:
        command = getCommand(line)
        comment = getComment(line)
        extrude = command.find(" E")
        if command.startswith("G1"):
            if getAxis("Z", command, zAxis) > zAxis:
                sys.stdout.write(".")
                zAxis = getAxis("Z",command,zAxis)
            prevX = xAxis
            prevY = yAxis
            xAxis = getAxis("X",command,xAxis)
            yAxis = getAxis("Y",command,yAxis)
            oldi = i
            oldj = j
            k = int(math.floor((zAxis - startingZ)/stepZ))
            i = int(math.ceil((xAxis - startingX + (k * shiftX) % stepX)/stepX))
            j = int(math.ceil((yAxis - startingY + (k * shiftY) % stepY)/stepY))
            if (oldi!=i or oldj!=j) and prevX != 0 and prevY != 0 and (prevX != xAxis or prevY != yAxis) and extrude != -1:
                for h in xrange(1,numInterpolated):
                    outfile.write("G1 X" + str(prevX + h * (xAxis - prevX) / numInterpolated) + " Y" + str(prevY + h * (yAxis - prevY) / numInterpolated) + " E1 ; " + "perimeter interpolated" + "\n")
                    pass
        outfile.write(line)
    print ""


# Scans through G-Code file and makes .gwl files
def runNotOnce(startingX,startingY,startingZ,endingX,endingY,endingZ,stepX,stepY,stepZ,shiftX,shiftY):
    sys.stdout.write("Parsing File: ")
    file = open(sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\Input.modif")
    xAxis = 0
    yAxis = 0
    zAxis = 0
    amountX = int(math.ceil((endingX - startingX)/stepX) + 1)
    amountY = int(math.ceil((endingY - startingY)/stepY) + 1)
    amountZ = int(math.ceil((endingZ - startingZ)/stepZ))
    firstX = 0
    firstY = 0
    firstZ = 0
    startX = [startingX + stepX*i for i in xrange(amountX)]
    startY = [startingY + stepY*i for i in xrange(amountY)]
    startZ = [startingZ + stepZ*i for i in xrange(amountZ)]
    outfilename = sys.argv[2]
    skipLayers = int(sys.argv[3]) + 1
    prevX = 0;
    prevY = 0;
    k = 0;
    inside = [[[False for k in xrange(amountZ)] for j in xrange(amountY)]for i in xrange(amountX)]
    extruding = False
    notnowWritelast = [[[False for k in xrange(amountZ)] for j in xrange(amountY)]for i in xrange(amountX)]
    for rawline in file:
        # Universal Start

        comment = getComment(rawline)
        command = getCommand(rawline)
        nowExtruding = not command.find(" E") == -1
        oldZAxis = zAxis
        if comment.startswith("move to next layer"):
            zAxis = getAxis("Z",command,zAxis)
            oldk = k
            k = int(math.floor((zAxis - startingZ)/stepZ))
            if oldZAxis == 0:
                zStep = zAxis
            rightLayer = (int(round(zAxis/zStep)) - 1) % skipLayers == 0
            if k != oldk:
                startX = [startingX + stepX*i - (k * shiftX) % stepX for i in xrange(amountX)]
                startY = [startingY + stepY*i - (k * shiftY) % stepY for i in xrange(amountY)]
                if zAxis!= zStep:
                    for i in xrange(amountX):
                        for j in xrange(amountY):
                            arrayoutfile[i][j].close()
                arrayoutfile = [[open(sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\File" + "_" + str(i) + "_" + str(j) + "_" + str(k) + ".gwl","w") for i in xrange(amountX)]for j in xrange(amountY)]
            sys.stdout.write('.')
        # Universal End

        if command.startswith("G1") and rightLayer:
            # Semi - Universal
            prevX = xAxis
            prevY = yAxis
            xAxis = getAxis("X",command,xAxis)
            yAxis = getAxis("Y",command,yAxis)
            # Semi - Universal End
            for i in xrange(amountX):
                for j in xrange(amountY):
                    outfile = arrayoutfile[i][j]
                    nowstartX = startX[i]
                    nowstartY = startY[j]
                    nowstartZ = startZ[k]
                    nowendX = nowstartX + stepX
                    nowendY = nowstartY + stepY
                    nowendZ = nowstartZ + stepZ
                    Writelast = notnowWritelast[i][j][k]
                    nowprevinside = inside[i][j][k]
                    inside[i][j][k] = xAxis >= nowstartX and xAxis <= nowendX and yAxis <= nowendY and yAxis >= nowstartY
                    nowinside = inside[i][j][k]

                    if not nowprevinside and nowinside and nowExtruding:

                        # Interpolates Point along X Direction
                        xPos = 0
                        yPos = 0
                        if prevY <= nowstartY and prevX >= nowstartX and prevX <= nowendX:
                            yPos = nowstartY
                        if prevY >= nowendY and prevX >= nowstartX and prevX <= nowendX:
                            yPos = nowendY
                        if yPos != 0 and (yPos - yAxis)*(yPos - prevY) < 0:
                            xPos = (xAxis * yPos - xAxis * prevY - prevX * yPos + prevX * yAxis) / (yAxis - prevY)
                            writeAxes(xPos,yPos,zAxis,"% Interpolated Point",outfile)
                            Writelast = False

                        # Interpolates Point along Y Direction
                        xPos = 0
                        yPos = 0
                        if prevX <= nowstartX and prevY >= nowstartY and prevY <= nowendY:
                            xPos = nowstartX
                        if prevX >= nowendX and prevY >= nowstartY and prevY <= nowendY:
                            xPos = nowendX
                        if xPos != 0 and (xPos - xAxis)*(xPos - prevX) < 0:
                            yPos = (yAxis * xPos - yAxis * prevX - prevY * xPos + prevY * xAxis) / (xAxis - prevX)
                            writeAxes(xPos,yPos,zAxis,"% Interpolated Point",outfile)
                            Writelast = False

                    if nowprevinside and not nowinside and nowExtruding:
                        # Interpolates Point along Y Direction
                        xPos = 0
                        yPos = 0
                        if xAxis <= nowstartX and yAxis <= nowendY and yAxis >= nowstartY:
                            xPos = nowstartX
                        if xAxis >= nowendX and yAxis <= nowendY and yAxis >= nowstartY:
                            xPos = nowendX
                        if xPos != 0 and (xPos - xAxis)*(xPos - prevX) < 0:
                            writeAxes(xPos,(yAxis * xPos - yAxis * prevX - prevY * xPos + prevY * xAxis) / (xAxis - prevX),zAxis,"% Interpolated Point",outfile)
                            Writelast = False
                        # Interpolates Point along X Direction
                        xPos = 0
                        yPos = 0
                        if yAxis <= nowstartY and xAxis <= nowendX and xAxis >= nowstartX:
                            yPos = nowstartY
                        if yAxis >= nowendY and xAxis <= nowendX and xAxis >= nowstartX:
                            yPos = nowendY
                        if yPos != 0 and (yPos - yAxis)*(yPos - prevY) < 0:
                            writeAxes((xAxis * yPos - xAxis * prevY - prevX * yPos + prevX * yAxis) / (yAxis - prevY),yPos,zAxis,"% Interpolated Point",outfile)
                            Writelast = False
                        if not Writelast:
                            outfile.write("Write\n")
                            Writelast = True;
                    if oldZAxis != zAxis and not Writelast:
                        outfile.write("Write\n")
                        Writelast = True
                    if nowExtruding and nowinside: #While it is Extruding
                        writeAxes(xAxis,yAxis,zAxis," ",outfile)
                        Writelast = False
                    if comment.startswith("move to first perimeter point") and not Writelast:
                        outfile.write("Write\n")
                        Writelast = True
                    notnowWritelast[i][j][k] = Writelast
    for i in xrange(amountX):
        for j in xrange(amountY):
            arrayoutfile[i][j].close()
    job = open(outfilename,"w")
    X_Pos = 0
    Y_Pos = 0
    Z_Pos = 0
    #job.write("MoveStageX " + str(-startingX) + "\n")
    #job.write("MoveStageY " + str(-startingY) + "\n")
    for k in xrange(amountZ):
        for j in xrange(amountY):
            for i in xrange(amountX):
                #job.write("MoveStageX " + str(-X_Pos + i * stepX) + "\n")
                #job.write("MoveStageY " + str(-Y_Pos + j * stepY) + "\n")
                #job.write("MoveStageZ " + str(-Z_Pos + k * stepZ) + "\n")
                #X_Pos = i * stepX
                #Y_Pos = j * stepY
                #Z_Pos = k * stepZ
                job.write("NewStructure\n")
                job.write("include " + sys.argv[1][:sys.argv[1].rindex("\\") + 1] + "Data\\File" + "_" + str(i) + "_" + str(j) + "_" + str(k) + ".gwl\n")
    job.close()


def main():
    # Start of Program
    MinsMaxs = getMinsMaxs(sys.argv[1])
    xMin = MinsMaxs[0]
    yMin = MinsMaxs[1]
    zMin = MinsMaxs[2]
    xMax = MinsMaxs[3]
    yMax = MinsMaxs[4]
    zMax = MinsMaxs[5]
    xStep = int(sys.argv[4])
    yStep = int(sys.argv[5])
    zStep = int(sys.argv[6])
    xShift = int(sys.argv[7])
    yShift = int(sys.argv[8])
    addingfirsts(sys.argv[1])
    interpolatingPoints(xMin,yMin,zMin,xMax,yMax,zMax,xStep,yStep,zStep,xShift,yShift)
    runNotOnce(xMin,yMin,zMin,xMax,yMax,zMax,xStep,yStep,zStep,xShift,yShift);


main()