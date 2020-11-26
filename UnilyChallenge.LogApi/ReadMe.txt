Instructions:
-------------
Using .net develop a microservice exposing an API that writes log messages from external services to a text file. The messages are to include an id, a date and up to 255 characters of text.

Candidates are encouraged to improvise on any points they might normally seek clarification on from that brief. Candidates aren’t expected to spend more than 3 hours on the project and submitting an incomplete project is acceptable.


Notes & assumptions
-------------------

1) I've assumed the location of the logfile being written to is not a shared resource between multiple instances, 
	otherwise some retry logic would definitely be required when trying to access the file for writing. It will currently write to the project folder. 
	I initially had it writing to a location defined in appSettings, however permissions etc would ofcourse cause pain.

2) Likewise, have assumed demand to write to this file is not too great, otherwise some form of queue would be required to manage the file contention.

3) I've added some basic tests (VERY basic in terms of the controller), could always do with more., for example checking that the file is being appended to, etc.
