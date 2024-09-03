<template>
  <div>
    <h1>Question Summary</h1>
    <c-loader-status :loaders="questionSummaries.$load" />
    <v-table>
      <thead>
        <tr>
          <th>Question Id</th>
          <th>Text</th>
          <th>Has Correct Answer</th>
          <th>Answer Count</th>
          <th>Category</th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="questionSummary in questionSummaries.$items"
          :key="questionSummary.$stableId"
        >
          <td>{{ questionSummary.id }}</td>
          <td>{{ questionSummary.text }}</td>
          <td>{{ questionSummary.hasCorrectAnswer }}</td>
          <td>{{ questionSummary.answerCount }}</td>
          <td>{{ Category[questionSummary.category ?? 0] }}</td>
        </tr>
      </tbody>
    </v-table>
    <c-list-pagination :list="questionSummaries" />
  </div>
</template>

<script setup lang="ts">
import { QuestionSummaryListViewModel } from "@/viewmodels.g";
import { Category } from "@/models.g";

const questionSummaries = new QuestionSummaryListViewModel();
questionSummaries.$load();
questionSummaries.$useAutoLoad();
</script>
