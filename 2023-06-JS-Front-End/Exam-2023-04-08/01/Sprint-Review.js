function solve(inputData) {
  const usersCount = Number(inputData.shift());
  const usersInput = inputData.splice(0, usersCount);
  const commands = {
    "Add User": addNewUser,
    "Add New": addNewTask,
    "Change Status": changeStatus,
    "Remove Task": removeTask,
  };
  const users = {};

  usersInput.forEach((input) => addNewUser(input));
  // console.log(JSON.stringify(users, null, 2));

  inputData.forEach((input) => {
    const commandInfo = input.split(":");
    const command = commandInfo.shift();
    commands[command](commandInfo);
  });

  // console.log(JSON.stringify(users, null, 2));

  const points = {
    ToDo: 0,
    "In Progress": 0,
    "Code Review": 0,
    Done: 0,
  };

  Object.values(users).forEach((user) => {
    user.forEach((task) => {
      points[task.status] += task.estimatedPoints;
    });
  });

  Object.entries(points).forEach((status) => {
    console.log(
      `${status[0] === "Done" ? status[0] + " Points" : status[0]}: ${
        status[1]
      }pts`
    );
  });

  if (
    points["Done"] >=
    points["ToDo"] + points["In Progress"] + points["Code Review"]
  ) {
    console.log("Sprint was successful!");
  } else {
    console.log("Sprint was unsuccessful...");
  }

  function addNewUser(info) {
    const [username, taskId, title, status, estimatedPoints] = info.split(":");
    const task = {
      taskId,
      title,
      status,
      estimatedPoints: Number(estimatedPoints),
    };
    if (!users.hasOwnProperty(username)) {
      users[username] = [task];
    } else {
      users[username].push(task);
    }
  }

  function addNewTask([assignee, taskId, title, status, estimatedPoints]) {
    if (!users.hasOwnProperty(assignee)) {
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }
    const task = {
      taskId,
      title,
      status,
      estimatedPoints: Number(estimatedPoints),
    };
    users[assignee].push(task);
  }

  function changeStatus([assignee, taskId, newStatus]) {
    if (!users.hasOwnProperty(assignee)) {
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }
    if (users[assignee].some((task) => task.taskId !== taskId)) {
      console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
      return;
    }
    users[assignee].find((task) => task.taskId === taskId).status = newStatus;
  }

  function removeTask([assignee, index]) {
    if (!users.hasOwnProperty(assignee)) {
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }
    if (!users[assignee][index]) {
      console.log(`Index is out of range!`);
      return;
    }
    delete users[assignee][index];
  }
}

// solve([
//   "5",
//   "Kiril:BOP-1209:Fix Minor Bug:ToDo:3",
//   "Mariya:BOP-1210:Fix Major Bug:In Progress:3",
//   "Peter:BOP-1211:POC:Code Review:5",
//   "Georgi:BOP-1212:Investigation Task:Done:2",
//   "Mariya:BOP-1213:New Account Page:In Progress:13",
//   "Add New:Kiril:BOP-1217:Add Info Page:In Progress:5",
//   "Change Status:Peter:BOP-1290:ToDo",
//   "Remove Task:Mariya:1",
//   "Remove Task:Joro:1",
// ]);
// console.log("--------------------------");
// solve([
//   "4",
//   "Kiril:BOP-1213:Fix Typo:Done:1",
//   "Peter:BOP-1214:New Products Page:In Progress:2",
//   "Mariya:BOP-1215:Setup Routing:ToDo:8",
//   "Georgi:BOP-1216:Add Business Card:Code Review:3",
//   "Add New:Sam:BOP-1237:Testing Home Page:Done:3",
//   "Change Status:Georgi:BOP-1216:Done",
//   "Change Status:Will:BOP-1212:In Progress",
//   "Remove Task:Georgi:3",
//   "Change Status:Mariya:BOP-1215:Done",
// ]);

solve([
  "6",
  "Peter:BOP-1214:New Products Page:ToDo:2",
  "Peter:BOP-1215:New Products Page:In Progress:2",
  "Peter:BOP-1216:New Products Page:Code Review:2",
  "Peter:BOP-1217:New Products Page:Done:2",
  "Mariya:BOP-1218:Setup Routing:Done:8",
  "Georgi:BOP-1219:Add Business Card:Code Review:3",
  "Remove Task:Peter:1",
  "Remove Task:Peter:2",
  "Remove Task:Kiril:2",
]);
