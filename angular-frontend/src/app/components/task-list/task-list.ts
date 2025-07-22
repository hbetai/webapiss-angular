import { Component } from '@angular/core';
import { Task } from '../../models/task.model';
import { TaskService } from '../../services/task';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-task-list',
  imports: [FormsModule, CommonModule],
  templateUrl: './task-list.html',
  styleUrl: './task-list.scss'
})
export class TaskList {

  tasks: Task[] = [];
  constructor(private taskService: TaskService) {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() {
    debugger;
    this.taskService.getTasks().subscribe(data => this.tasks = data);
  }

  deleteTask(id: number) {
    this.taskService.deleteTask(id).subscribe(() => this.loadTasks());
  }

  toggleComplete(task: Task) {
    task.isCompleted = !task.isCompleted;
    this.taskService.updateTask(task).subscribe();
  }

}
