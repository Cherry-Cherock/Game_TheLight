-- id                               int                              ID
-- date                             date(input=yyyy-MM-dd 
HH:mm:ss|toLua=#dateTable|toDatabase=#1970sec)   日期
-- title                            string                           名字

return {
	[2100] = {
		date = os.date("!*t", 1472659200),
		title = "新学期报到",
	},
	[2000] = {
		date = os.date("!*t", 1473436800),
		title = "教师节",
	},
	[2001] = {
		date = os.date("!*t", 1473868800),
		title = "中秋节",
	},
	[2102] = {
		date = os.date("!*t", 1475078400),
		title = "月考",
	},
	[2103] = {
		date = os.date("!*t", 1475164800),
		title = "月考",
	},
	[2002] = {
		date = os.date("!*t", 1475251200),
		title = "国庆节",
	},
	[2104] = {
		date = os.date("!*t", 1477497600),
		title = "月考",
	},
	[2105] = {
		date = os.date("!*t", 1477584000),
		title = "月考",
	},
	[2108] = {
		date = os.date("!*t", 1479916800),
		title = "期中考",
	},
	[2109] = {
		date = os.date("!*t", 1480003200),
		title = "期中考",
	},
	[2110] = {
		date = os.date("!*t", 1482336000),
		title = "月考",
	},
	[2111] = {
		date = os.date("!*t", 1482422400),
		title = "月考",
	},
	[2009] = {
		date = os.date("!*t", 1451577600),
		title = "元旦节",
	},
	[2112] = {
		date = os.date("!*t", 1484150400),
		title = "期末考",
	},
	[2113] = {
		date = os.date("!*t", 1484236800),
		title = "期末考",
	},
	[2010] = {
		date = os.date("!*t", 1485446400),
		title = "除夕",
	},
	[2011] = {
		date = os.date("!*t", 1485532800),
		title = "春节",
	},
	[2101] = {
		date = os.date("!*t", 1486828800),
		title = "开学",
	},
	[2013] = {
		date = os.date("!*t", 1487001600),
		title = "情人节",
	},
	[2131] = {
		date = os.date("!*t", 1488211200),
		title = "百日誓师大会",
	},
	[2114] = {
		date = os.date("!*t", 1488384000),
		title = "一模",
	},
	[2115] = {
		date = os.date("!*t", 1488470400),
		title = "一模",
	},
	[2116] = {
		date = os.date("!*t", 1490803200),
		title = "二模",
	},
	[2117] = {
		date = os.date("!*t", 1490889600),
		title = "二模",
	},
	[2018] = {
		date = os.date("!*t", 1491235200),
		title = "清明节",
	},
	[2118] = {
		date = os.date("!*t", 1493222400),
		title = "三模",
	},
	[2119] = {
		date = os.date("!*t", 1493308800),
		title = "三模",
	},
	[2019] = {
		date = os.date("!*t", 1493568000),
		title = "劳动节",
	},
	[2137] = {
		date = os.date("!*t", 1496073600),
		title = "端午节",
	},
	[2120] = {
		date = os.date("!*t", 1496764800),
		title = "高考",
	},
}
