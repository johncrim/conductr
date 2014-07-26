#!/bin/sh
pushd src/Service
mono bin/Debug/Conductr.exe --gc=sgen
popd