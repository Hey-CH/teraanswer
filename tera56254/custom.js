
$(document).ready(function(){
	var rcnt=0;
	var arr=new Array();
	arr.push({
	"item1": {"name": "i1",
			"items":{
				"item1-1": {"name": "i1-1"},
				"item1-2": {"name": "i1-2"},
				"item1-3": {"name": "i1-3"}
			}
			},
	"item2": {"name": "i2"},
	"item3": {"name": "i3"}
	});
	alert(arr.constructor.name);
	$.contextMenu({ 
		selector: "p", 
		callback: function(key, options) {
			try{
			var subarr={};
			if(rcnt==0){
				subarr.push({"sup":"----------"});
			}
			subarr.push({"item2": {"name": "i2"}});
			rcnt++;
			}catch(e){
			alert(e.toString());
			}
		}, 
		items: arr 
	});
});