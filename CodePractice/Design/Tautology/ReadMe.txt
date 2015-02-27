I found some more time after first submission to implement one of the enhancement idea which I had suggested in my previous mail which is 
"Evaluating without execution" 

I am achieving this by constructing a composite tree and applying some basic rules at each level. I've not made teh rules exhaustive but enough to 
demonstrate the idea and cover the basic test cases. 

All other deductions could be implemented in the same way.

Assumption:
	'!' operator doesnt work on complex operands.. eg., !(a|b). Reason : Felt its time consuming to implement and its just logic extension.

***************************************************************
A glimpse into my thought process:
Since the word 'Tautology' was alien to me, I spent time reading about 'Propositional Calculus', 'Tautology','Contradiction','Contingency' chiefly from 
this website http://www.zweigmedia.com/RealWorld/logic/logic1.html

Having understood the domain, the first idea that came to mind was to design a composite object structure with one/more operands and zero or one operator. Basically, an expression tree (in C#) which will convert the expression to a piece of code which can then be compiled and run with input parameters (variables from the truth table). 

I dropped that idea because of the line in mail 'Please send us a solution that involves hand coded parsing and evaluation logic without the use of ScriptEngine or its equivalents' 

So the only option that I knew was good old postfix evaluation using stack. Once I had postfix notation, then it was brute force to evaluate it with every possible values in truth table.

10 variables capped the truth table to 2^10 combination (which is relatively small). Otherwise, I would have introduced some data parallelism using TPL. Or could have introduced some logic to simplify statements as outlined in http://people.umass.edu/partee/409/Deduction_I.pdf 
