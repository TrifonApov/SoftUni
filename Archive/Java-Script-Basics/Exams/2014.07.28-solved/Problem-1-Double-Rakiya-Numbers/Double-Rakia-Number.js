function rakia(input) {
    var start = Number(input[0]);
    var end = Number(input[1]);

    var result = '<ul>' + '\n';

    for (var i = start; i <= end; i++) {
        var isRakia = chekcIsRakia(i);
        if (isRakia) {
            result += '<li><span class=\'rakiya\'>' + i + '</span><a href="view.php?id=' + i + '>View</a></li>' + '\n';
        } else {
            result += '<li><span class=\'num\'>' + i + '</span></li>' + '\n';
        }
    }

    function chekcIsRakia(isRakia) {
        var yOrN = false;
        isRakia = isRakia.toString();
        for (var i = 0; i < isRakia.length-3; i++) {
            var isBreak = false;
            var twoDigits = isRakia[i]+isRakia[i+1];
            for (var j = i+2; j < isRakia.length-1; j++) {
                var currTwoDig = isRakia[j]+isRakia[j+1];
                if (twoDigits === currTwoDig) {
                    yOrN = true;
                    isBreak = true;
                    break;
                }

            }
            if (isBreak) {
                break;
            }
        }
        if (yOrN) {
            return true;
        } else {
            return false;
        }
    }
    result+='</ul>';
    console.log(result);
    return result;
}

rakia([11210,11215]);
//<ul>
//'<li><span class='num'> + i + </span></li>'
//<li><span class='rakiya'>11211</span><a href="view.php?id=11211">View</a></li>
//<li><span class='rakiya'>11212</span><a href="view.php?id=11212">View</a></li>
//<li><span class='num'>11213</span></li>
//<li><span class='num'>11214</span></li>
//<li><span class='num'>11215</span></li>
//</ul>