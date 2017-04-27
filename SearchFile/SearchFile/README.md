# Assessment
Find all files that have at least one instance of the given text.

Download a Searchfile

Enter the follwing ways

Syntax:

        searchfile [-o] [-f] "string" ["string"]
		
		
		searchfile     : Is a Command
		
		-o             : Is Conditions to apply OR operations
		
		-f             : Is Conditions to apply matching Group of words
		
		whitespace     : Ia Conditions to apply AND operations

		
Example:

1.Matching one single words
   
  Syntax:   :> searchfile "string" 
  
	example  :> searchfile the
	
	
2.OR Conditions

  Syntax:    :> searchfile -o "string" "string"
  
    example:   :> searchfile -o cats dogs
   
   
3.AND condition

  Syntax:    :> searchfile "string" "string"
  
    example:   :> searchfile dogs cats
	
	
4. -f apply :

  Syntax:    :> searchfile -f "group of words"
  
    example:   :> searchfile Dogs and cats
	