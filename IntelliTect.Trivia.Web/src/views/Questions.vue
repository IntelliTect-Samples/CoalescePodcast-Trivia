<template>
  <v-container>
    <h1>Questions</h1>

    <QuestionCard
      :question="question"
      class="mb-2"
      v-for="question in questions.$items"
      :key="question.$stableId"
    />
  </v-container>
</template>

<script setup lang="ts">
import { QuestionListViewModel } from "@/viewmodels.g";

const questions = new QuestionListViewModel();
questions.$load();
</script>
