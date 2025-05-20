# Instructions
Given two buckets of different size and which bucket to fill first, determine how many actions are required to measure an exact number of liters by strategically transferring fluid between the buckets.

## Rules

You can only do one action at a time.

- There are only 3 possible actions:
    - Pouring one bucket into the other bucket until
        - The first bucket is empty
        - The second bucket is full
    - Emptying a bucket and doing nothing to the other.
    - Filling a bucket and doing nothing to the other.

>After an action, you may not arrive at a state where the initial starting bucket is empty and the other bucket is full.

## Input

- Size of bucket one
- Size of bucket two
- Number of liters to reach
- Which bucket to fill first
    - Bucket one
    - Bucket two

## Output

- Total number of actions it should take to reach the desired number of liters
    - Including the first fill of the starting bucket
- Which bucket ends up with the desired number of liters
    - Bucket one
    - Bucket two
- How many liters are left in the other bucket

>Note: any time a change is made to either or both buckets counts as one (1) action.

### Example 1

- Bucket one can hold up to 7 liters
- Bucket two can hold up to 11 liters

#### Scenario

- Bucket one is holding 7 liters
- Bucket two is holding 8 liters
- (7,8)

#### Options

- Option 1
    - Empty bucket one and make no change to bucket two
    - Leaves 0 liters and 8 liters respectively
    - (0,8)
- Option 2
    - Pour from bucket one into bucket two until bucket two is full
    - Makes 4 liters in bucket one and 11 liters respectively
    - (4,11)

Both options count as one action.

### Example 2

- Bucket one can hold 3 liters
- Bucket two can hold up to 5 liters
- You must start with bucket one

So your first action is to fill bucket one.  
You choose to empty bucket one for your second action.  
For your third action, you may not fill bucket two, because this violates the third rule
> You may not end up in a state after any action where the starting bucket is empty and the other bucket is full.

Written with <3 at [Fullstack Academy](https://www.fullstackacademy.com/) by Lindsay Levine.

#### Source [Water Pouring Problem](https://demonstrations.wolfram.com/WaterPouringProblem/)