In the previous submission, my mindset was that of solving online coding challenges where the chief goal is solving for time complexity. 
That is why, you would have seen the BruteForce implementation - which evaluates all 2^n combinations (n - number of vocabulary variables) followed
by OptimizedEngine - which evaluates without executiong. And both of them using ShuntingYard postfix algorithm implemented using primitive if-else/switch statements.

It wasn't that I was unaware of the evils of switch but I had preconceived idea (solving for time complexity) about approaching the problem and the lines 'coding challenge', 
'hand coded parsing and evaluation logic without the use of ScriptEngine or its equivalents', 'clean, simple, elegant' misguided me. 
I probably saw what my mind wanted me to see :) 
And that made me solve chiefly for time complexity, though I left comments over switch statements suggesting possible redesign.

Solution being rejected on grounds of nesting/library non-usage, I have refactored it. In addition to code refactoring, I've made the following changes
	*	Instead of Shunting-Yard algorithm, I'm introducing more efficient EBNF approach which is solved using recursive descent. 		
		 The syntax used can be summarized in EBNF as below
				 Expression      = Binary
				 Binary          = Unary ("|"|"&") Unary 
				 Unary           = ("!") Primary 
				 Primary         = Variable | "(" Expression ")" 

	*	I've handled extra conditions which I had previously omitted 

	        "( !(a & a) | (a | !a))"

            "( !(a & b) | (a & b))"

            "( !(a & ((b & (a | !a))| c)) | (a & (b|c)))"

            "( !(a & !(a))"

            "!(a & !a)"

            "( !(a & !(!b)) | (a & b))"

            "( !a | (a & !(b & !b)))"
	
These changes can be tracked from RefactoredPropositionalEngine.cs. I've also left the old code in place in case you wanted to refer (BruteForce/Optimized)PropositionalEngine

If there is anything that could be bettered, I would like to discuss and learn. Thanks for your time.





***************************************************************
Notes from previuos submission:
***************************************************************
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

