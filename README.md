# Javascript Array Extensions


- It is an array extensions that can be used **javascript** and **node.js**.
- It is just likes C# extension methods or lambda expression can be used.
- It is more fantastic with https://github.com/powerumc/js-lambda

# Use it

Nuget
```js
PM> Install-Package JS.Array.Extensions
```

Node.JS
```
$ npm install js-array-extensions

require('js-array-extensions');
```


# Support methods

- any
- first
- firstOrDefault
- firstOrNew
- last
- lastOrDefault
- lastOrNew
- where
- select
- foreach
- orderBy
- take
- skip
- sum
- average
- max
- min
- range and Array.range
- union
- clone
- distinct
- innerJoin
- outerJoin             - working
- groupBy               - working

## **Basics**

**any( predicate )**
```js
[1,2,3,4,5].any();                                  // True
[1,2,3,4,5].any(function(i) { return i > 3; });     // True
[1,2,3,4,5].any(function(i) { return i > 5; });     // False
```
**first( predicate )**
```js
[1,2,3].first();    // 1

[3,5,6].firstOrNew(function(i) { return i > 5; });      // 6
[3,5,6].firstOrNew(function(i) { return i > 6; });      // []    is new Array()

[3,6,9].firstOrDefault();                               // 3
[3,6,9].firstOrDefault(function(i) { return i > 3; });  // 6
[3,4,5].firstOrDefault(function(i) { return i > 5; });  // Null
```
**last( predicate )**
```js
[3,6,9].last();                                 // 9
[3,6,9].last(function(i) { return i > 100; });  // throw null references

[3,6,9].lastOrDefault();                                // 9
[3,6,9].lastOrDefault(function(i) { return i < 9 });    // 6

[3,6,9].lastOrNew(function(i) { return i < 5 });    // 3
[3,6,9].lastOrNew(function(i) { return i < 2; });   // []    is new Array()
```


## **Selector and Condition**

**select( selector )**

```js
var arr = [ { "key": "powerumc",    "value": "http://blog.powerumc.kr" },
            { "key": "devth",       "value": "http://devwith.com" },
            { "key": "domain",      "value": "http://powerumc.kr" }];

var selected = arr.select(function(o) {
    return { name: o.key, website: o.value };
});

// results var selected
select name=powerumc,   website=http://blog.powerumc.kr
select name=devth,      website=http://devwith.com
select name=domain,     website=http://powerumc.kr
```

**where( selector )**
```js
var arr = [ { "key": "powerumc",    "value": "http://blog.powerumc.kr" },
            { "key": "devth",       "value": "http://devwith.com" },
            { "key": "domain",      "value": "http://powerumc.kr" }];

var selected = arr.where(function(o) {
    return o.value.lastIndexOf(".kr") > 0
});

// results var selected
where lastIndexOf('.kr')=http://blog.powerumc.kr
where lastIndexOf('.kr')=http://powerumc.kr
```

**take( number )**
```js
var arr = [1,2,3,4,5,6,7,8,9,10];
var take =  arr.take(5).toString();

// results var take
take = 1,2,3,4,5
```

**skip( number )**
```js
var arr = [1,2,3,4,5,6,7,8,9,10];
var skip = arr.skip(5).toString();

// results var skip
skip = 6,7,8,9,10
```

**take and skip**
```js
var arr         = [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20];
var take        = 5;
var count       = 5;
var page        = 2;
var pagingList  = arr.skip( page * count ).take(take);

// results
take and skip 11,12,13,14,15
```


**Array.distinct( first, second, ... )**
```js
		var first 	= [1, 2, 3, 4, 5];
		var second 	= [1, 2, 3, 4, 5, 6, 7, 8, 9];
		var third 	= [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];

		var result  = Array.distinct(first, second, third);

		console.info(result);

		// result
		// 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
```


**Array.distinct( first, second, ... )**
```js
var first 	= [1, 2, 3, 4, 5];
var second 	= [1, 2, 3, 4, 5, 6, 7, 8, 9];
var third 	= [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];

var result  = Array.distinct(first, second, third);

console.info(result);

// result
// 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
```



## **Loop**

**foreach ( i, object, args )**
```js
var arr = [ { "key": "powerumc",    "value": "http://blog.powerumc.kr" },
            { "key": "devth",       "value": "http://devwith.com" },
            { "key": "domain",      "value": "http://powerumc.kr" }];

arr.foreach(function(o) {
    console.info("foreach o=" + o.key);
});

// results
foreach o=powerumc
foreach o=devth
foreach o=domain


arr.foreach(function(i, o) {
   console.info("foreach i=" + i + " key=" + o.key);
});

// results
foreach i=0 key=powerumc
foreach i=1 key=devth
foreach i=2 key=domain


arr.foreach(function(i, o, arg) {
   console.info("foreach i=" + i + " key=" + o.key + "  arg=" + arg);
}, "this is arguments");

// results
foreach i=0 key=powerumc,   arg=this is arguments
foreach i=1 key=devth,      arg=this is arguments
foreach i=2 key=domain,     arg=this is arguments
```

**foreach ( i, object, args )** _with foreach.continue_
```js
var arr = [ { "key": "powerumc",    "value": "http://blog.powerumc.kr" },
            { "key": "devth",       "value": "http://devwith.com" },
            { "key": "domain",      "value": "http://powerumc.kr" }];

arr.foreach(function(i, o) {
    if( i > 1) {
        return foreach.continue;
    }

    console.info("foreach continue i = " + i + ",   key = " + o.key);
});

// results
foreach continue i = 0,   key = powerumc
foreach continue i = 1,   key = devth
```


**foreach ( i, object, args )** with _foreach.break_
```js
var arr = [ { "key": "powerumc",    "value": "http://blog.powerumc.kr" },
            { "key": "devth",       "value": "http://devwith.com" },
            { "key": "domain",      "value": "http://powerumc.kr" }];

arr.foreach(function(i, o) {
    if( i == 1 ) {
        return foreach.break;
    }

    console.info("foreach break i = " + i + "   key = " + o.key);
});

// results
foreach break i = 0   key = powerumc
```


## Sort

**orderBy( comparer )**
```js
var arr = [ 23, 8, 43 ,81, 4, 32, 64 ];
arr = arr.orderBy();

// results
orderBy (default) 4
orderBy (default) 8
orderBy (default) 23
orderBy (default) 32
orderBy (default) 43
orderBy (default) 64
orderBy (default) 81
```

**orderBy( comparer )** with _comparer.ascending or comparer.asc_
```js
var arr = [ 23, 8, 43 ,81, 4, 32, 64 ];
arr = arr.orderBy(comparer.ascending);

// results
orderBy comparer.ascending 4
orderBy comparer.ascending 8
orderBy comparer.ascending 23
orderBy comparer.ascending 32
orderBy comparer.ascending 43
orderBy comparer.ascending 64
orderBy comparer.ascending 81
```

**orderBy( comparer )** with _comparer.descending or cmoparer.desc_
```js
var arr = [ 23, 8, 43 ,81, 4, 32, 64 ];
arr = arr.orderBy(comparer.descending);

// results
orderBy comparer.descending 81
orderBy comparer.descending 64
orderBy comparer.descending 43
orderBy comparer.descending 32
orderBy comparer.descending 23
orderBy comparer.descending 8
orderBy comparer.descending 4
```

## Combination


**Array.union( first, second )**
```js
var first   = [1,2,3,[4,5]];
var second  = [[6,7,8],9,10];
var union    = first.union(second);

// results var union
array[0] = 1
array[1] = 2
array[2] = 3
array[3] = [4,5]
array[4] = [6,7,8]
array[5] = [9]
array[6] = [10]
```

**Object.union( first, second )**
```js
var person1 = { "name"      : { first:"Junil", last:"Um" },
                "address"   : { country:"South Korea", city:"Seoul" },
                "email"     : "powerumc at gmail" };
var person2 = { "name"      : { first:"Apple", last:"MacBook" },
                "address"   : { country:"U.S", city:"N/A" },
                "email"     : "apple@apple.com" };

var union   = Object.union(person1, person2);

// results var union
array[0] =  { "name"      : { first:"Junil", last:"Um" },
              "address"   : { country:"South Korea", city:"Seoul" },
              "email"     : "powerumc at gmail" }
array[1] =  { "name"      : { first:"Apple", last:"MacBook" },
              "address"   : { country:"U.S", city:"N/A" },
              "email"     : "apple@apple.com" }
```

## Join

**Array.innerJoin( first, second, primaryKey, foreignKey, selector )**
```js
var firstjoin = [ 	{ name: "Junil Um" },
					{ name: "Chulsu" },
					{ name: "Jane" },
					{ name: "Paris" } ];

var secondjoin = [ 	{ name: "Junil Um", 	addr: { addr1: "Junil Addr1", 			addr2: "Junil Addr2" }},
					{ name: "Chulsu.", 		addr: { addr1: "Chulsu Addr1", 			addr2: "Chulsu Addr2" }},
					{ name: "Jane", 		addr: { addr1: "Jane Addr1", 			addr2: "Jane Addr2" }},
					{ name: "Paris...",		addr: { addr1: "Paris Addr1",		 	addr2: "Paris Addr2" }} ];

var result = firstjoin.join( secondjoin, function(a) { return a.name; },
										 function(b) { return b.name; },
										 function(a,b) { return { a: a.name, b: b.addr.addr1 }; });
```



## Numbers

**sum( selector )**
```js
var arr = [1,2,3,4,5,6,7,8,9,10];
var sum = arr.sum();                                  // 55

var arr = [1,2,3,"4",5,6,7,8, "9", "10.5"];
var sum = arr.sum();                                  // 55.5

var arr = [1,2,3,4,5,6,7,8,9, 10.5];
var sum = arr.sum(function(i) { return i / 2; });     // 27.75
```

**average( selector )**
```js
var arr = [1,2,3,4,5,6,7,8,9,10];
var avg = arr.average();                               // 5.5

var arr = [1,2,3,"4",5,6,7,8, "9", "10.5"];             // 5.55
var avg = arr.average();

var arr = [1,2,3,4,5,6,7,8,9, 10.5];
var avg = arr.average(function(i) { return i * 2; });   // 11.1
}
```

**range(start, max, step )** and **Array.range( start, max, step )** _likes range method of python language._

```js
var arr = [0,1,2,3,4,5];
arr.range(6, 10);                   // 0,1,2,3,4,5,6,7,8,9  ** arr passed reference type **

var range = [].range(0,10);         // 0,1,2,3,4,5,6,7,8,9

var arr = Array.range(10);          // 0,1,2,3,4,5,6,7,8,9
var arr = Array.range(10, 20);      // 10,11,12,13,14,15,16,17,18,19
var arr = Array.range(0, 10, 2);    // 0,2,4,6,8

```

## Objects and Array

**Object.clone( first, second )**
```js
var person = {  "name"      : { first:"Junil", last:"Um" },
                "address"   : { country:"South Korea", city:"Seoul" },
                "email"     : "powerumc at gmail" };

var clone = Object.clone(person);

// results var clone
{  "name"      : { first:"Junil", last:"Um" },
   "address"   : { country:"South Korea", city:"Seoul" },
   "email"     : "powerumc at gmail" }
```

**Array.clone( first, second )**
```js
var arrNum = [1,2,3,4,5,6,7,8,9,10];
var clone  = Object.clone(arrNum);

// results var clone
1,2,3,4,5,6,7,8,9,10
```

**union( second )**
```js
var first    = [1,2,3,4,5];
var second   = [6,7,8,9,10];
var union    = first.union(second);

// results var union
array.union = 1,2,3,4,5,6,7,8,9,10
```