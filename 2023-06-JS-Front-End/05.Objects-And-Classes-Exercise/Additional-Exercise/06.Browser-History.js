function solve (browserInfo, commands) {
    class Browser {
        constructor(name, openTabs, recentlyClosed, logs){
            this.name = name;
            this.openTabs = openTabs,
            this.recentlyClosed = recentlyClosed;
            this.logs = logs;
        }

        openTab(site) {
            this.openTabs.push(site);
            this.logs.push(`Open ${site}`);
        }

        closeTab(site) {
            if (this.openTabs.includes(site)){
                const index = this.openTabs.indexOf(site);
                this.openTabs.splice(index, 1);
                this.recentlyClosed.push(site);
                this.logs.push(`Close ${site}`);
            }
        }

        clear(){
            this.openTabs = [];
            this.recentlyClosed = [];
            this.logs = [];
        }
    }
    const name = browserInfo["Browser Name"];
    const openTabs = browserInfo["Open Tabs"];
    const recentlyClosed = browserInfo["Recently Closed"];
    const browserLogs = browserInfo["Browser Logs"];
    const browser = new Browser(name, openTabs, recentlyClosed, browserLogs);

    commands.forEach(command => {
        const [action, site] = command.split(' ');
        switch(action){
            case 'Open': browser.openTab(site); break;
            case 'Close': browser.closeTab(site); break;
            case 'Clear': browser.clear(); break;
        }
    });
    console.log(browser.name);
    console.log(`Open Tabs: ${browser.openTabs.join(', ')}`);
    console.log(`Recently Closed: ${browser.recentlyClosed.join(', ')}`);
    console.log(`Browser Logs: ${browser.logs.join(', ')}`);
    // console.log(JSON.stringify(browser, null, 3));
}


solve(
{
	"Browser Name":"Google Chrome",
	"Open Tabs": ["Facebook","YouTube","Google Translate"],
	"Recently Closed":["Yahoo","Gmail"],
	"Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"]
},
["Close Facebook", "Open StackOverFlow", "Open Google"]);
console.log('\n\n\n');
solve(
    {
        "Browser Name":"Mozilla Firefox",
        
        "Open Tabs":["YouTube"],
        
        "Recently Closed":["Gmail", "Dropbox"],
        
        "Browser Logs":["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
    },
    
    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
)