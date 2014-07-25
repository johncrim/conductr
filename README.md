Conductr
=====

Job management web service, self-hosted web app, and job plugin model in .NET.

Initial setup
======
Running as an administrator, give the user or group that will be running Conductr permissions to listen on the configured port.  The default port is 7063 (numeric version of "jobm").  Eg:

    netsh http add urlacl url=http://+:7063/ user=.\Users listen=yes
    REM Optional - Verify ACL:
    netsh http show urlacl url=http://+:7063/

Next, open up port 7063 (or whichever port you'll be using) on your firewall if applicable.

