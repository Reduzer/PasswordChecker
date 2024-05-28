# PasswordChecker

This program checks if a password has been found in any dataleeks.
It hashes the input password with various hashing algorithms and searches the haveibeenpwned database for any matches.
As for sending the entire hash not beeing safe, it only sends the first five characters from the hash to see if it finds any matches and return a list of passwords that might be the users input, so the user themself can look if the password has been found

## ToDo
Will be implemented in the Server sided application of the MessengerService
