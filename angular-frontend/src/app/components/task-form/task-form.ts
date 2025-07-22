import { Component } from '@angular/core';
import { TaskService } from '../../services/task';
import { Task } from '../../models/task.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-form',
  imports: [FormsModule],
  templateUrl: './task-form.html',
  styleUrl: './task-form.scss',
})
export class TaskForm {
  taskTitle: string = '';

  constructor(private taskService: TaskService) {}

  addTask() {
    if (!this.taskTitle.trim()) return;
    const newTask: Task = { title: this.taskTitle, isCompleted: false };
    //this.taskService.addTask(newTask).subscribe(() => this.taskTitle = '');
    this.taskService.addTask(newTask).subscribe((result) => {
      console.log('Task added:', result);
    });
  }
}
