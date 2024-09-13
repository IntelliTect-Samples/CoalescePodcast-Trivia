<template>
  <div>
    <h1>Question Summary</h1>
    {{ selectedIds }}
    <c-loader-status :loaders="questionSummaries.$load" />
    <v-table>
      <thead>
        <tr>
          <th></th>
          <th>Text</th>
          <th>Has Correct Answer</th>
          <th>Answer Count</th>
          <th>Category</th>
        </tr>
      </thead>
      <tbody>
        <QuestionSummaryRow
          v-for="questionSummary in questionSummaries.$items"
          :key="questionSummary.$stableId"
          :questionSummary="questionSummary"
          @selectionChanged="selectionChanged"
        />
      </tbody>
    </v-table>
    <c-list-pagination :list="questionSummaries" />
  </div>
</template>

<script setup lang="ts">
import { QuestionSummaryListViewModel } from "@/viewmodels.g";

const selectedIds = ref<string[]>([]);

const questionSummaries = new QuestionSummaryListViewModel();
questionSummaries.$load();
questionSummaries.$useAutoLoad();

function selectionChanged(isSelected: boolean, id: string) {
  if (isSelected) {
    selectedIds.value.push(id);
  } else {
    selectedIds.value = selectedIds.value.filter((x) => x !== id);
  }
}
</script>
