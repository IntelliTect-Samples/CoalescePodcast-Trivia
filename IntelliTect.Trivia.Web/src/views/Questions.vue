<template>
  <v-container>
    <h1>Random Question</h1>
    <QuestionCard
      v-if="randomQuestion !== null"
      :question="randomQuestion"
      class="mb-2"
    />

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
import {
  QuestionListViewModel,
  QuestionServiceViewModel,
} from "@/viewmodels.g";

const questions = new QuestionListViewModel();
questions.$load();

const questionService = new QuestionServiceViewModel();
questionService.getRandomQuestion();

const randomQuestion = computed(() => questionService.getRandomQuestion.result);
</script>
