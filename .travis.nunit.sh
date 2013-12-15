#!/bin/sh -x

mono --runtime=v4.5 .nuget/NuGet.exe install NUnit.Runners -Version 2.6.3 -o packages

runTest() {
    mono --runtime=v4.5 packages/NUnit.Runners.2.6.3/tools/nunit-console.exe -noxml -nodots -labels -stoponerror $@
    if [ $? -ne 0 ]
    then
        exit 1
    fi
}

runTest $1 -exclude=Performance

exit $?